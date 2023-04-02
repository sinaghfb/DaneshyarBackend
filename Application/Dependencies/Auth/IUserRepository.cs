using Application.Dependencies.Base;
using Domain.Entites.Auth;
using Domain.Entites.BaseInfo;

namespace Application.Dependencies.Auth
{
    public interface IUserRepository: IBaseRepository<string, User> 
    {
        public void UpdateUser(User user);
        public Task<bool> DeleteUser(string UserId);
    }
}
