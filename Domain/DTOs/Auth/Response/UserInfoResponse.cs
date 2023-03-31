using Domain.DTOs.Base.Response;
using Domain.Enums;

namespace Domain.DTOs.Auth.Response
{
    public class UserInfoResponse:BaseResponse
    {
        public string?  UserName{ get; set; }
        public string? Name { get; set; }
        public string? FatherName { get; set; }
        public string? Family { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? NationalNo { get; set; }
        public AccessLevel UserAccessLevel { get; set; }
    }
}
