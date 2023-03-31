using Application.Dependencies.Base;
using Domain.Entites.Auth;

namespace Application.Dependencies.Auth
{
    public interface IRoleRepository:IBaseRepository<string,Role>
    {
        public Task<bool> UpdateRole(Role role);
        public Task<bool> DeleteRole(string RoleId);
    }
}
