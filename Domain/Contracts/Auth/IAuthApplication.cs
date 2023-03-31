using Domain.DTOs.Auth.Request;
using Domain.DTOs.Auth.Response;

namespace Domain.Contracts.Auth
{
    public interface IAuthApplication
    {
        public Task<BaseUserResponse> UserLogin(UserLoginRequest user);
        public Task<BaseUserResponse> AddAnotherUser(AddAnotherUserRequest user);
        public Task<BaseUserResponse> NewUserRegister(NewUserRegisterRequest user);
        public Task<BaseUserResponse> ChangeUserPassword(ChangePasswordRequest user);
        public Task<BaseUserResponse> DeleteUser(BaseUserRequest user);
        public Task<BaseUserResponse> UpdateUser(UpdateUserRequest user);
        public Task<UserInfoResponse> GetUserInfo(BaseUserRequest user);

    }
}
