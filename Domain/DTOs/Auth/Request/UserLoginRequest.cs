namespace Domain.DTOs.Auth.Request
{
    public class UserLoginRequest:BaseUserRequest
    {
        public string? password { get; set; }
    }
}
