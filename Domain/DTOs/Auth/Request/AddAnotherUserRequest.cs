using Domain.Enums;

namespace Domain.DTOs.Auth.Request
{
    public class AddAnotherUserRequest
    {
        public string? PersonId { get; set; }
        public string? NationalNo { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? MobileNo { get; set; }
        public AccessLevel UserAccessLevel { get; set; }
    }
}
