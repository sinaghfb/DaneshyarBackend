using Domain.DTOs.Base.Response;

namespace Domain.DTOs.Auth.Response
{
    public class BaseUserResponse : BaseResponse
    {
        public string? UserName { get; set; }
        public string? PersonId { get; set; }
        public string? UserId { get; set; }
    }
}
