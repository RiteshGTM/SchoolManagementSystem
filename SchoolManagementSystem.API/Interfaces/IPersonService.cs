using SchoolManagementSystem.API.Models;

namespace SchoolManagementSystem.API.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPeople();

        Task<Person> GetPersonById(Guid personId);

        Task AddPerson(Person person);

        Task UpdatePerson(Person person);

        Task DeletePerson(Guid personId);
    }
}