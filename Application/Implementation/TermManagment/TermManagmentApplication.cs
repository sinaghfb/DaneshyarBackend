using Application.Dependencies.TermManagment;
using Domain.Contracts.TermManagment;
using Domain.DTOs.TermManagment.Request;
using Domain.DTOs.TermManagment.Response;
using Domain.Entites.TermManagment;

namespace Application.Implementation.TermManagment
{
    public class TermManagmentApplication : ITermManagment
    {
        private readonly ITermRepository _termRepository;
        private readonly ITermCourseRepository _termCourseRepository;

        public TermManagmentApplication(ITermRepository termtRepository, ITermCourseRepository termCourseRepository)
        {
            _termRepository = termtRepository;
            _termCourseRepository = termCourseRepository;
        }
        public async Task<AddTermResponse> AddTerm(AddTermRequest addTerm)
        {
            AddTermResponse response = new();
            Term newTerm = new();
            try
            {

                newTerm.StartYear = addTerm.StartYear;
                newTerm.EndYear = addTerm.EndYear;
                newTerm.TermTitle = addTerm.TermTitle;
                newTerm.TermNo = addTerm.TermNo;
                newTerm.TermCount = addTerm.TermCount;
                _termRepository.Create(newTerm);
                await _termRepository.SaveChanges();
                response.TermId = newTerm.Id;
                response.Status = Domain.Enums.ResponseStateEnum.Success;
                return response;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<AddTermCourseResponse> AddTermCourse(AddTermCourseRequest addTermCourseRequest)
        {
            AddTermCourseResponse response = new();
            TermCourse newTermCourse = new();
            try
            {
                var foundTerm = await _termRepository.Get(addTermCourseRequest.TermId);
                if (foundTerm != null)
                {
                    newTermCourse.TeacherName = addTermCourseRequest.TeacherName;
                    newTermCourse.StartHour = addTermCourseRequest.StartHour;
                    newTermCourse.EndHour = addTermCourseRequest.EndHour;
                    newTermCourse.Capacity = addTermCourseRequest.Capacity;
                    newTermCourse.CourseId = addTermCourseRequest.CourseId;
                    newTermCourse.Location = addTermCourseRequest.Location;
                    newTermCourse.Day = addTermCourseRequest.Day;
                    newTermCourse.ExamDate = addTermCourseRequest.ExamDate;
                    newTermCourse.ExamStartHour = addTermCourseRequest.ExamStartHour;
                    newTermCourse.ExamEndHour = addTermCourseRequest.ExamEndHour;
                    newTermCourse.EntraceYear = addTermCourseRequest.EntraceYear;
                    newTermCourse.TermId = addTermCourseRequest.TermId;
                    foundTerm.TermCourseList.Add(newTermCourse);
                    await _termRepository.SaveChanges();
                    response.Status = Domain.Enums.ResponseStateEnum.Success;

                    response.TermId = newTermCourse.TermId;
                    response.TermCourseId = newTermCourse.Id;
                    response.Message = "درس ترم با موفقیت اضافه شد";
                }
                else
                {
                    response.Status = Domain.Enums.ResponseStateEnum.NotFound;
                    response.Message = "ترم مورد نظر یافت نشد";

                }
            }
            catch (Exception ex)
            {
                response.Message = "اضافه کردن درس ترم با خطا مواجه شد";
                response.Status = Domain.Enums.ResponseStateEnum.Exception;
                response.Description = ex.Message;

            }
            return response;
        }

        public async Task<DeleteTermResponse> DeleteTerm(string termId)
        {
            DeleteTermResponse response = new();
            try
            {
                await _termRepository.DeleteTerm(termId);
                await _termRepository.SaveChanges();
                response.Status = Domain.Enums.ResponseStateEnum.Success;
                response.Message = "عملیات حذف ترم موفقیت آمیز بود";

            }
            catch (Exception ex)
            {
                response.Status = Domain.Enums.ResponseStateEnum.Exception;
                response.Message = "عملیات حذف ترم موفقیت آمیز بود";
                response.Description = ex.Message;
            }
            return response;
        }

        public async Task<DeleteTermCourseResponse> DeleteTermCourse(string termCourseId)
        {
            DeleteTermCourseResponse response = new();
            try
            {
                await _termCourseRepository.DeleteTermCourse(termCourseId);
                response.Status = Domain.Enums.ResponseStateEnum.Success;
                response.Message = "عملیات حذف درس ترم موفقیت آمیز بود";

            }
            catch (Exception ex)
            {
                response.Status = Domain.Enums.ResponseStateEnum.Exception;
                response.Message = "عملیات حذف درس ترم با خطا مواجه شد";
                response.Description = ex.Message;
            }
            return response;
        }

        public async Task<GetAllTermCoursesResponse> GetAllTermCourses(string termId)
        {
            GetAllTermCoursesResponse response = new();
            try
            {
                var term = await _termRepository.Get(termId);
                if (term.TermCourseList.Count > 0)
                {
                    foreach (var termCourseDetail in term.TermCourseList)
                    {


                        TermCourseItem item = new();
                        item.StartHour = termCourseDetail.StartHour;
                        item.EndHour = termCourseDetail.EndHour;
                        item.ExamStartHour = termCourseDetail.ExamStartHour;
                        item.ExamEndHour = termCourseDetail.ExamEndHour;
                        item.CourseId = termCourseDetail.CourseId;
                        item.TermCourseId = termCourseDetail.Id;
                        item.Day = termCourseDetail.Day;
                        item.EntraceYear = termCourseDetail.EntraceYear;
                        item.ExamDate = termCourseDetail.ExamDate;
                        item.Location = termCourseDetail.Location;
                        item.TermCourseNo = termCourseDetail.TermCourseNo;
                        item.TeacherName = termCourseDetail.TeacherName;
                        item.TermId = termCourseDetail.TermId;
                        response.TermCourses.Add(item);
                    }
                    response.Status = Domain.Enums.ResponseStateEnum.Success;
                    response.Message = "بازیابی درس ترم موفقیت آمیز بود";
                }
                else
                {
                    response.Status = Domain.Enums.ResponseStateEnum.Exception;
                    response.Message = "درس ترم یافت نشد";
                }

            }
            catch (Exception ex)
            {

                response.Status = Domain.Enums.ResponseStateEnum.Exception;
                response.Message = "بازیابی درس ترم با خطا مواجه شد";
                response.Description = ex.Message;
            }
            return response;
        }

        public async Task<GetAllTermsResponse> GetAllTermCourses()
        {
            GetAllTermsResponse response = new();
            try
            {
                var result = await _termRepository.Get();
                foreach (var item in result)
                {
                    TermItem termItem = new();
                    termItem.StartYear = item.StartYear;
                    termItem.EndYear = item.EndYear;
                    termItem.TermId = item.Id;
                    termItem.TermNo = item.TermNo;
                    termItem.TermCount = item.TermCount;
                    termItem.TermTitle = item.TermTitle;
                    response.Terms.Add(termItem);
                }
                response.Message = "بازیابی ترم ها موفقیت آمیز بود";
                response.Status = Domain.Enums.ResponseStateEnum.Success;
            }
            catch (Exception ex)
            {

                response.Message = "بازیابی ترم ها با خطا مواجه شد";
                response.Status = Domain.Enums.ResponseStateEnum.Exception;
                response.Description = ex.Message;
            }
            return response;
        }

        public async Task<GetTermCourseDetailResponse> GetTermCourseDetail(string termCourseId)
        {
            GetTermCourseDetailResponse response = new();
            try
            {
                var termCourseDetail = await _termCourseRepository.Get(termCourseId);
                if (termCourseDetail != null)
                {
                    TermCourseItem item = new();
                    item.StartHour = termCourseDetail.StartHour;
                    item.EndHour = termCourseDetail.EndHour;
                    item.ExamStartHour = termCourseDetail.ExamStartHour;
                    item.ExamEndHour = termCourseDetail.ExamEndHour;
                    item.CourseId = termCourseDetail.CourseId;
                    item.TermCourseId = termCourseDetail.Id;
                    item.Day = termCourseDetail.Day;
                    item.EntraceYear = termCourseDetail.EntraceYear;
                    item.ExamDate = termCourseDetail.ExamDate;
                    item.Location = termCourseDetail.Location;
                    item.TermCourseNo = termCourseDetail.TermCourseNo;
                    item.TeacherName = termCourseDetail.TeacherName;
                    item.TermId = termCourseDetail.TermId;
                    response.TermCourse = item;
                    response.Status = Domain.Enums.ResponseStateEnum.Success;
                    response.Message = "بازیابی درس ترم موفقیت آمیز بود";
                }
                else
                {
                    response.Status = Domain.Enums.ResponseStateEnum.Exception;
                    response.Message = "درس ترم یافت نشد";
                }

            }
            catch (Exception ex)
            {

                response.Status = Domain.Enums.ResponseStateEnum.Exception;
                response.Message = "بازیابی درس ترم با خطا مواجه شد";
                response.Description = ex.Message;
            }
            return response;
        }

        public async Task<GetTermDetailResponse> GetTermDetail(string termId)
        {
            GetTermDetailResponse response = new();
            try
            {
                var result = await _termRepository.Get(termId);

                TermItem termItem = new();
                termItem.StartYear = result.StartYear;
                termItem.EndYear = result.EndYear;
                termItem.TermId = result.Id;
                termItem.TermNo = result.TermNo;
                termItem.TermCount = result.TermCount;
                termItem.TermTitle = result.TermTitle;
                response.Term = termItem;

                response.Message = "بازیابی ترم  موفقیت آمیز بود";
                response.Status = Domain.Enums.ResponseStateEnum.Success;
            }
            catch (Exception ex)
            {
                response.Message = "بازیابی ترم ها با خطا مواجه شد";
                response.Status = Domain.Enums.ResponseStateEnum.Exception;
                response.Description = ex.Message;
            }
            return response;
        }

        public Task<PredictExamDateResponse> PredictExamDate(PredictExamDateRequest predictExamDate)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public async Task<RecoverTermCourseResponse> RecoverTermCourse(RecoverTermCourseRequest recoverTermCourseRequest)
        {
            RecoverTermCourseResponse response = new();
            try
            {
                var recoverTerm = await _termRepository.Get(recoverTermCourseRequest.RecoverTermCourseId);
                if (recoverTerm != null)
                {
                    if (recoverTerm.TermCourseList.Count > 0)
                    {
                        var currentTerm = await _termRepository.Get(recoverTermCourseRequest.CurrentTermCourseId);
                        if (currentTerm != null)
                        {
                            currentTerm.TermCourseList = recoverTerm.TermCourseList;
                            await _termRepository.SaveChanges();
                            response.Status = Domain.Enums.ResponseStateEnum.Success;
                            response.Message = "بازیابی درس ترم موفقیت آمیز بود";
                        }
                        else
                        {
                            response.Status = Domain.Enums.ResponseStateEnum.NotFound;
                            response.Message = "ترم جاری یافت نشد";
                        }
                    }
                    else
                    {
                        response.Status = Domain.Enums.ResponseStateEnum.Success;
                        response.Message = "ترم مورد انتخاب برای بازیابی درسی ندارد";
                    }
                }
                else
                {
                    response.Status = Domain.Enums.ResponseStateEnum.Success;
                    response.Message = "ترم بازیابی وجود ندارد";
                }
            }
            catch (Exception ex)
            {

                response.Status = Domain.Enums.ResponseStateEnum.Exception;
                response.Message = "بازیابی درس ترم با خطا مواجه شد";
                response.Description = ex.Message;
            }
            return response;
        }

        public async Task<UpdateTermResponse> UpdateTerm(UpdateTermRequest updateTerm)
        {
            var response = new UpdateTermResponse();
            try
            {
                var foundTerm = await _termRepository.Get(updateTerm.TermId);
                if (foundTerm != null)
                {
                    foundTerm.StartYear = updateTerm.StartYear;
                    foundTerm.EndYear = updateTerm.EndYear;
                    foundTerm.TermTitle = updateTerm.TermTitle;
                    foundTerm.TermNo = updateTerm.TermNo;
                    foundTerm.TermCount = updateTerm.TermCount;
                    await _termRepository.SaveChanges();

                    response.Message = "به روز رسانی موفقیت آمیز بود";
                    response.Status = Domain.Enums.ResponseStateEnum.Success;
                }
                else
                {
                    response.Message = "ترم یافت نشد";
                    response.Status = Domain.Enums.ResponseStateEnum.NotFound;
                }
            }
            catch (Exception ex)
            {

                response.Message = "بازیابی ترم ها با خطا مواجه شد";
                response.Status = Domain.Enums.ResponseStateEnum.Exception;
                response.Description = ex.Message;
            }
            return response;
        }

        public async Task<UpdateTermCourseResponse> UpdateTermCourse(UpdateTermCourseRequest updateTermCourseRequest)
        {
            UpdateTermCourseResponse response = new();
            try
            {
                var termCourseDetail = await _termCourseRepository.Get(updateTermCourseRequest.TermCourseId);
                if (termCourseDetail != null)
                {
                    termCourseDetail.StartHour = updateTermCourseRequest.StartHour;
                    termCourseDetail.EndHour = updateTermCourseRequest.EndHour;
                    termCourseDetail.ExamStartHour = updateTermCourseRequest.ExamStartHour;
                    termCourseDetail.ExamEndHour = updateTermCourseRequest.ExamEndHour;
                    termCourseDetail.CourseId = updateTermCourseRequest.CourseId;
                    termCourseDetail.Day = updateTermCourseRequest.Day;
                    termCourseDetail.EntraceYear = updateTermCourseRequest.EntraceYear;
                    termCourseDetail.ExamDate = updateTermCourseRequest.ExamDate;
                    termCourseDetail.Location = updateTermCourseRequest.Location;
                    termCourseDetail.TermCourseNo = updateTermCourseRequest.TermCourseNo;
                    termCourseDetail.TeacherName = updateTermCourseRequest.TeacherName;
                    response.Status = Domain.Enums.ResponseStateEnum.Success;
                    response.Message = "بازیابی درس ترم موفقیت آمیز بود";
                    await _termCourseRepository.SaveChanges();
                }
                else
                {
                    response.Status = Domain.Enums.ResponseStateEnum.Exception;
                    response.Message = "درس ترم یافت نشد";
                }
            }
            catch (Exception)
            {

                response.Status = Domain.Enums.ResponseStateEnum.Exception;
                response.Message = "درس ترم یافت نشد";
            }
            return response;
        }
    }
}
