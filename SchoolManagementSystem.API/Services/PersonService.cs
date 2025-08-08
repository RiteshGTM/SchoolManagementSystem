using SchoolManagementSystem.API.Interfaces;
using SchoolManagementSystem.API.Models;

namespace SchoolManagementSystem.API.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await personRepository.GetAllPeople();
        }

        public async Task<Person> GetPersonById(Guid personId)
        {
            return await personRepository.GetPersonById(personId);
        }

        public async Task AddPerson(Person person)
        {
            await personRepository.AddPerson(person);
        }

        public async Task UpdatePerson(Person person)
        {
            await personRepository.UpdatePerson(person);
        }

        public async Task DeletePerson(Guid personId)
        {
            await personRepository.DeletePerson(personId);
        }
    }
}