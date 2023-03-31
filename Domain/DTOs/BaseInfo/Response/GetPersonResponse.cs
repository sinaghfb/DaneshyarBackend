using Domain.DTOs.Base.Response;

namespace Domain.DTOs.BaseInfo.Response
{
    public class GetPersonResponse:BaseResponse
    {
        public string? PersonId { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? FatherName { get; set; }
        public string? NationalNo { get; set; }
    }
}
