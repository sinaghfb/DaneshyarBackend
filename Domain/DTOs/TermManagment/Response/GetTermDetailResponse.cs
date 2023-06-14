using Domain.DTOs.Base.Response;


namespace Domain.DTOs.TermManagment.Response
{
    public class GetTermDetailResponse:BaseResponse
    {
        public GetTermDetailResponse()
        {
            Term = new();
        }
        public TermItem Term { get; set; }
    }
}
