using RiseTech.API.Repositories;
using RiseTech.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RiseTech.Data.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(PhoneBookContext phoneBookContext) : base(phoneBookContext) { }

        public void AddPerson(Person person) => Create(person);

        public void DeletePerson(Person person) => Delete(person);

        public IEnumerable<Person> GetPeople() => FindAll().ToList();

        public Person GetPersonByID(int id) => FindByCondition(p => p.Id == id).FirstOrDefault();

        public void UpdatePerson(Person person) => Update(person);
    }
}
