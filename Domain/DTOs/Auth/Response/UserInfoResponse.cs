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
        public string? UserId { get; set; }
        public string? PersonId { get; set; }
        public string? FullName { get; set; }
        public AccessLevelEnum UserAccessLevel { get; set; }
    }
}
