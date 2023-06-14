using Domain.DTOs.Base.Response;

namespace Domain.DTOs.TermManagment.Response
{
    public class GetAllTermsResponse:BaseResponse
    {
        public GetAllTermsResponse()
        {
            Terms = new();
        }
        public List<TermItem> Terms { get; set; }
    }
}
