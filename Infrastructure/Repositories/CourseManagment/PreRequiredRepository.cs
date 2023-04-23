using Application.Dependencies.CourseManagmanet;
using Domain.Entites.CourseManagment;
using Domain.Enums;
using Infrastructure.Contexts.CourseManagment;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CourseManagment
{
    internal class PreRequiredRepository : BaseRepository<string, PreRequired>, IPreRequiredRepository
    {
        private readonly PreRequiredContext _preRequiredContext;
        public PreRequiredRepository(PreRequiredContext preRequiredContext) : base(preRequiredContext)
        {
            _preRequiredContext = preRequiredContext;
        }

        public async Task<bool> DeletePreRequired(string Id)
        {
            var foundedRole = await _preRequiredContext.PreRequireds.FirstOrDefaultAsync(x => x.Id == Id);
            if (foundedRole != null)
            {
                foundedRole.State = ObjectStateEnum.Deleted;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
