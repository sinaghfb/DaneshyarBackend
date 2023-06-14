using Domain.DTOs.Base.Response;

namespace Domain.DTOs.TermManagment.Response
{
    public class GetTermCourseDetailResponse:BaseResponse
    {
        public GetTermCourseDetailResponse()
        {
            TermCourse = new();
        }
        public TermCourseItem TermCourse { get; set; }
    }
}
