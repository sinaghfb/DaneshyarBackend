using Application.Dependencies.Base;
using Domain.Entites.BaseInfo;

namespace Application.Dependencies.BaseInfo
{
    public interface IPersonRepository : IBaseRepository<string, Person>
    {
        public Task<bool> UpdatePerson(Person person);
        public Task<bool> DeletePerson(string PersonId);

    }
}
