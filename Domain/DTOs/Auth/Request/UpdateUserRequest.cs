using Domain.Enums;

namespace Domain.DTOs.Auth.Request
{
    public class UpdateUserRequest
    {
        public string? UserId { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? NationalNo { get; set; }
        public string? FatherName { get; set; }
        public AccessLevelEnum UserAccessLevel { get; set; }
    }
}
