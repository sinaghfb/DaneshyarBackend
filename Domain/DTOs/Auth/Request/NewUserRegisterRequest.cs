using Domain.Enums;

namespace Domain.DTOs.Auth.Request
{
    public class NewUserRegisterRequest
    {
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? NationalNo { get; set; }
        public string? FatherName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? MobileNo { get; set; }
        public AccessLevelEnum UserAccessLevel { get; set; }
    }
}
