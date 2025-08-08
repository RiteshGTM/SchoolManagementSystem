using SchoolManagementSystem.API.Models;

namespace SchoolManagementSystem.API.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPeople();

        Task<Person> GetPersonById(Guid PersonId);

        Task AddPerson(Person person);

        Task UpdatePerson(Person person);

        Task DeletePerson(Guid PersonId);
    }
}
