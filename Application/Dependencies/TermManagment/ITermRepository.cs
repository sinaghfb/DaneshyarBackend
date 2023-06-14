using Application.Dependencies.Base;
using Domain.Entites.TermManagment;

namespace Application.Dependencies.TermManagment
{
    public interface ITermRepository:IBaseRepository<string,Term>
    {
        Task<bool> DeleteTerm(string Id);

    }
}
