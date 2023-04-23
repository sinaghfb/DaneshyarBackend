using Domain.DTOs.Base.Response;
using Domain.DTOs.CourseManagment.Request;
using Domain.DTOs.CourseManagment.Response;

namespace Domain.Contracts.CourseManagment
{
    public interface ICourseManagment
    {
        Task<GetAllCoursesResponse> GetAllCourses();
        Task<GetCourseResponse> GetCourseDetail(GeneralCourseRequest request);
        Task<AddCourseResponse> AddCourse(AddCourseRequest request);
        Task<BaseResponse> DeleteCourse(GeneralCourseRequest request);
        Task<BaseResponse> UpdateCourse(UpdateCourseResquest request);
    }
}
