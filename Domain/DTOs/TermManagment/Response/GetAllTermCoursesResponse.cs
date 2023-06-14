using Domain.DTOs.Base.Response;

namespace Domain.DTOs.TermManagment.Response
{
    public class GetAllTermCoursesResponse:BaseResponse
    {
        public GetAllTermCoursesResponse()
        {
            TermCourses = new();
        }
        public List<TermCourseItem> TermCourses { get; set; }
    }
}
