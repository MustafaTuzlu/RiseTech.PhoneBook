using RiseTech.Data.Entities;
using System.Collections.Generic;

namespace RiseTech.API.Repositories
{
    public interface IPersonRepository
    {
        public IEnumerable<Person> GetPeople();
        public Person GetPersonByID(int id);
        public void AddPerson(Person person);
        public void UpdatePerson(Person person);
        public void DeletePerson(Person person);
    }
}
