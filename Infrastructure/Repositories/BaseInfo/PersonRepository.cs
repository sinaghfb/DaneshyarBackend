using Application.Dependencies.BaseInfo;
using Domain.Entites.BaseInfo;
using Domain.Enums;
using Infrastructure.Contexts.BaseInfo;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BaseInfo
{
    public class PersonRepository : BaseRepository<string, Person>, IPersonRepository
    {
        private readonly PersonContext _personContext;
        public PersonRepository(PersonContext personContext) : base(personContext)
        {
            _personContext = personContext;
        }
        public async Task<bool> DeletePerson(string PersonId)
        {
            var foundedPerson=await _personContext.Persons.FirstOrDefaultAsync(x => x.Id == PersonId);    
            if (foundedPerson != null)
            {
                foundedPerson.State = ObjectStateEnum.Deleted;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdatePerson(Person person)
        {
            _personContext.Persons.Update(person);
        }
    }
}
