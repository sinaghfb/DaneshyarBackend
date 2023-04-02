using Application.Dependencies.Base;
using Domain.Entites.BaseInfo;

namespace Application.Dependencies.BaseInfo
{
    public interface IPersonRepository : IBaseRepository<string, Person>
    {
        public void UpdatePerson(Person person);
        public Task<bool> DeletePerson(string PersonId);

    }
}
