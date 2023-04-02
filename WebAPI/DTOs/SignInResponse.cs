using Domain.DTOs.Auth.Response;

namespace WebAPI.DTOs
{
    public class SignInResponse
    {
        public string accessToken { get; set; }
        public BaseUserResponse user  { get; set; }
    }
}
