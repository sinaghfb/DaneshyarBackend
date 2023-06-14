using Application.Dependencies.TermManagment;
using Domain.Entites.TermManagment;
using Domain.Enums;
using Infrastructure.Contexts.TermManagment;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.TermManagment
{
    public class TermRepository: BaseRepository<string,Term>,ITermRepository
    {
        private readonly TermContext _termContext;
        public TermRepository(TermContext termContext) : base(termContext)
        {
            _termContext = termContext;
        }
        public async Task<bool> DeleteTerm(string Id)
        {
            var foundedRole = await _termContext.Terms.FirstOrDefaultAsync(x => x.Id == Id);
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
