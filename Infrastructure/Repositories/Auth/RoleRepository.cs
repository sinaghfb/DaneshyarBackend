using Application.Dependencies.Auth;
using Application.Dependencies.Base;
using Domain.Entites.Auth;
using Domain.Enums;
using Infrastructure.Contexts.Auth;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.Auth
{
    public class RoleRepository : BaseRepository<string, Role>, IRoleRepository
    {
        private readonly RoleContext _roleContext;
        public RoleRepository(RoleContext roleContext) : base(roleContext)
        {
            _roleContext = roleContext;
        }

        public async Task<bool> DeleteRole(string roleId)
        {
            var foundedRole= await _roleContext.Roles.FirstOrDefaultAsync(x=>x.Id== roleId);
            if (foundedRole!=null)
            {
                foundedRole.State = ObjectStateEnum.Deleted;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void UpdateRole(Role role)
        {
            _roleContext.Roles.Update(role);
        }


    }
}
