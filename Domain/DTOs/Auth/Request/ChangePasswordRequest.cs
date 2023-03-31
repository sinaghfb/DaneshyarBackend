namespace Domain.DTOs.Auth.Request
{
    public class ChangePasswordRequest:BaseUserRequest
    {
        public string? NewPassword { get; set; }
    }
}
