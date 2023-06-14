using Domain.DTOs.Base.Response;


namespace Domain.DTOs.TermManagment.Response
{
    public class AddTermCourseResponse:BaseResponse
    {
        public string TermId { get; set; }
        public string TermCourseId { get; set; }
    }
}
