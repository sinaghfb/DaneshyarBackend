using Application.Dependencies.Auth;
using Domain.Entites.Auth;
using Domain.Enums;
using Infrastructure.Contexts.Auth;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Auth
{
    public class UserRepository : BaseRepository<string, User>, IUserRepository
    {
        private readonly UserContext _userContext;
        public UserRepository(UserContext userContext) : base(userContext)
        {
            _userContext = userContext;
        }
        public async Task<bool> DeleteUser(string UserId)
        {
            var foundedUser = await _userContext.Users.FirstOrDefaultAsync(x => x.Id == UserId);
            if (foundedUser != null) {
                foundedUser.State = ObjectState.Deleted;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateUser(User user)
        {
            _userContext.Users.Update(user);
        }
    }
}
