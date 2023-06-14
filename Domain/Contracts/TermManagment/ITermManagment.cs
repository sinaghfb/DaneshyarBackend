using Domain.DTOs.TermManagment.Request;
using Domain.DTOs.TermManagment.Response;

namespace Domain.Contracts.TermManagment
{
    public interface ITermManagment
    {
        Task<GetAllTermsResponse> GetAllTermCourses();
        Task<GetAllTermCoursesResponse> GetAllTermCourses(string termId);
        Task<AddTermResponse> AddTerm(AddTermRequest addTerm);
        Task<DeleteTermResponse> DeleteTerm(string termId);
        Task<UpdateTermResponse> UpdateTerm(UpdateTermRequest updateTerm);
        Task<GetTermDetailResponse> GetTermDetail(string termId);
        Task<AddTermCourseResponse> AddTermCourse(AddTermCourseRequest addTermCourseRequest);
        Task<DeleteTermCourseResponse> DeleteTermCourse(string termCourseId);
        Task<UpdateTermCourseResponse> UpdateTermCourse(UpdateTermCourseRequest updateTermCourseRequest);
        Task<GetTermCourseDetailResponse> GetTermCourseDetail(string termCourseId);
        Task<PredictExamDateResponse> PredictExamDate(PredictExamDateRequest predictExamDate);
        Task<RecoverTermCourseResponse> RecoverTermCourse(RecoverTermCourseRequest recoverTermCourseRequest);
    }
}
