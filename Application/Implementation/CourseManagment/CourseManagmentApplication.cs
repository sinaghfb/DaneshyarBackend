using Application.Dependencies.CourseManagmanet;
using Domain.Contracts.CourseManagment;
using Domain.DTOs.Base.Response;
using Domain.DTOs.CourseManagment.Request;
using Domain.DTOs.CourseManagment.Response;
using Domain.Entites.CourseManagment;
using Domain.Enums;
using EnumsNET;

namespace Application.Implementation.CourseManagment
{
    public class CourseManagmentApplication : ICourseManagment
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IPreRequiredRepository _PreRequiredRepository;


        public CourseManagmentApplication(ICourseRepository courseRepository,
            IPreRequiredRepository preRequiredRepository)
        {
            _courseRepository = courseRepository;
            _PreRequiredRepository = preRequiredRepository;
        }
        public async Task<AddCourseResponse> AddCourse(AddCourseRequest request)
        {
            AddCourseResponse response = new();
            try
            {
                Course course = new();
                course.CourseCode = request.CourseCode;
                course.CourseName = request.CourseName;
                course.CourseNo = request.CourseNo;
                course.CourseType = (CourseTypeEnum)int.Parse(request.CourseType.Id);
                course.UnitCount = request.UnitCount;
                _courseRepository.Create(course);
                await _courseRepository.SaveChanges();
                foreach (var item in request.PreRequireds)
                {
                    PreRequired preRequired = new();
                    preRequired.RequiredCourseId = course.Id;
                    preRequired.PreRequiredCourseId = item.Id;
                    _PreRequiredRepository.Create(preRequired);
                    await _PreRequiredRepository.SaveChanges();
                }
                response.Status = ResponseStateEnum.Success;
                response.Message = "درس با موفقیت انجام شد";
                response.CourseId = course.Id;
            }
            catch (Exception ex)
            {

                response.Status = ResponseStateEnum.Exception;
                response.Message = "ثبت درس با خطا مواجه شد";
                response.CourseId = string.Empty;
                response.Description = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse> DeleteCourse(GeneralCourseRequest request)
        {
            BaseResponse response = new();
            try
            {
                if (!string.IsNullOrWhiteSpace(request.CourseId))
                {
                    if (await _courseRepository.DeleteCourse(request.CourseId))
                    {
                        await _courseRepository.SaveChanges();
                        response.Status = ResponseStateEnum.Success;
                        response.Message = "درس با موفقیت حذف شد";
                    }
                    else
                    {
                        response.Status = ResponseStateEnum.Failed;
                        response.Message = "درس با وجود ندارد";
                    }

                }
                else
                {
                    var foundCourse = _courseRepository.Get(x => x.CourseNo == request.CourseNo);
                    if (foundCourse != null)
                    {
                        if (await _courseRepository.DeleteCourse(request.CourseId))
                        {
                            await _courseRepository.SaveChanges();
                            response.Status = ResponseStateEnum.Success;
                            response.Message = "درس با موفقیت حذف شد";
                        }
                        else
                        {
                            response.Status = ResponseStateEnum.Failed;
                            response.Message = "درس با وجود ندارد";
                        }
                    }
                    else
                    {
                        response.Status = ResponseStateEnum.Failed;
                        response.Message = "درس با وجود ندارد";
                    }

                }
            }
            catch (Exception ex)
            {

                response.Status = ResponseStateEnum.Exception;
                response.Message = "ثبت درس با خطا مواجه شد";
                response.Description = ex.Message;
            }
            return response;
        }

        public async Task<GetAllCoursesResponse> GetAllCourses()
        {
            GetAllCoursesResponse response = new();
            try
            {
                List<Course> allCourses = await _courseRepository.Get();

                foreach (var course in allCourses)
                {
                    CourseInfo courseInfo = new();
                    courseInfo.CourseNo = course.CourseNo;
                    courseInfo.CourseId = course.Id;
                    courseInfo.CourseName = course.CourseName;
                    courseInfo.CourseCode = course.CourseCode;
                    courseInfo.CourseType.Title = (course.CourseType).AsString(EnumFormat.Description);
                    courseInfo.CourseType.Id = ((int)course.CourseType).ToString();
                    courseInfo.UnitCount = course.UnitCount;
                    foreach (var item in course.Requireds)
                    {
                        SelectModel selectModel = new();
                        selectModel.Id = item.PreRequiredCourse.Id;
                        selectModel.Title = item.PreRequiredCourse.CourseName;
                        courseInfo.PreRequireds.Add(selectModel);
                    }
                    response.Courses.Add(courseInfo);
                }
                response.Status = ResponseStateEnum.Success;
                response.Message = "درس با موفقیت بازیابی شد";
            }
            catch (Exception ex)
            {

                response.Status = ResponseStateEnum.Exception;
                response.Message = "بازیابی درس با خطا مواجه شد";
                response.Description = ex.Message;
            }
            return response;
        }

        public async Task<GetCourseResponse> GetCourseDetail(GeneralCourseRequest request)
        {
            GetCourseResponse response = new();
            try
            {
                if (!string.IsNullOrWhiteSpace(request.CourseId))
                {
                    var course = await _courseRepository.Get(request.CourseId);
                    if (course != null)
                    {
                        CourseInfo courseInfo = new();
                        courseInfo.CourseNo = course.CourseNo;
                        courseInfo.CourseId = course.Id;
                        courseInfo.CourseName = course.CourseName;
                        courseInfo.CourseCode = course.CourseCode;
                        courseInfo.CourseType.Title = (course.CourseType).AsString(EnumFormat.Description);
                        courseInfo.CourseType.Id = ((int)course.CourseType).ToString();
                        courseInfo.UnitCount = course.UnitCount;
                        foreach (var item in course.Requireds)
                        {
                            SelectModel selectModel = new();
                            selectModel.Id = item.PreRequiredCourse.Id;
                            selectModel.Title = item.PreRequiredCourse.CourseName;
                            courseInfo.PreRequireds.Add(selectModel);
                        }
                        response.DetailInfo= courseInfo;
                    }
                    else
                    {
                        response.Status = ResponseStateEnum.NotFound;
                        response.Message = "درس وجود ندارد";
                    }
                }
                else if (!string.IsNullOrWhiteSpace(request.CourseNo))
                {
                    var course = await _courseRepository.Get(x => x.CourseNo == request.CourseNo);
                    if (course != null)
                    {
                        CourseInfo courseInfo = new();
                        courseInfo.CourseNo = course.CourseNo;
                        courseInfo.CourseId = course.Id;
                        courseInfo.CourseName = course.CourseName;
                        courseInfo.CourseCode = course.CourseCode;
                        courseInfo.CourseType.Title = (course.CourseType).AsString(EnumFormat.Description);
                        courseInfo.CourseType.Id = ((int)course.CourseType).ToString();
                        courseInfo.UnitCount = course.UnitCount;
                        foreach (var item in course.Requireds)
                        {
                            SelectModel selectModel = new();
                            selectModel.Id = item.PreRequiredCourse.Id;
                            selectModel.Title = item.PreRequiredCourse.CourseName;
                            courseInfo.PreRequireds.Add(selectModel);
                        }
                        response.Status = ResponseStateEnum.Success;
                        response.Message = "درس با موفقیت بازیابی شد";
                        response.DetailInfo = courseInfo;
                    }
                    else
                    {
                        response.Status = ResponseStateEnum.NotFound;
                        response.Message = "درس وجود ندارد";
                    }
                }
                else
                {
                    response.Status = ResponseStateEnum.Failed;
                    response.Message = "پارامتر های ورودی خالی است";
                }
            }
            catch (Exception ex)
            {


                response.Status = ResponseStateEnum.Exception;
                response.Message = "بازیابی درس با خطا مواجه شد";
                response.Description = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse> UpdateCourse(UpdateTermResquest request)
        {
            AddCourseResponse response = new();
            try
            {
                Course course = await _courseRepository.Get(x => x.Id == request.CourseId);
                course.CourseCode = request.CourseCode;
                course.CourseName = request.CourseName;
                course.CourseNo = request.CourseNo;
                course.CourseType = (CourseTypeEnum)int.Parse(request.CourseType.Id);
                course.UnitCount = request.UnitCount;
                _courseRepository.UpdateCourse(course);
                await _courseRepository.SaveChanges();
                foreach (var item in request.PreRequireds)
                {
                    if (!course.Requireds.Exists(x => x.Id == item.Id))
                    {
                        PreRequired preRequired = new();
                        preRequired.RequiredCourseId = course.Id;
                        preRequired.PreRequiredCourseId = item.Id;
                        _PreRequiredRepository.Create(preRequired);
                        await _PreRequiredRepository.SaveChanges();
                    }
                }
                foreach (var item in course.Requireds)
                {
                    if (!request.PreRequireds.Any(x=>x.Id==item.Id))
                    {
                        await _PreRequiredRepository.DeletePreRequired(item.Id);
                        await _PreRequiredRepository.SaveChanges();
                    }
                }
                response.Status = ResponseStateEnum.Success;
                response.Message = " ثبت درس با موفقیت انجام شد";
                response.CourseId = course.Id;
            }
            catch (Exception ex)
            {

                response.Status = ResponseStateEnum.Exception;
                response.Message = "ثبت درس با خطا مواجه شد";
                response.CourseId = string.Empty;
                response.Description = ex.Message;
            }

            return response;
        }
    }
}
