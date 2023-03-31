using Domain.DTOs.Base.Request;

namespace Domain.DTOs.Auth.Request
{
    public class BaseUserRequest:BaseRequest
    {
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? UserName { get; set; }
    }
}
