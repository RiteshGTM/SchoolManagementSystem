using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.API.Data;
using SchoolManagementSystem.API.Interfaces;
using SchoolManagementSystem.API.Models;

namespace SchoolManagementSystem.API.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly SchoolDbContext dbContext;

        public PersonRepository(SchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await dbContext.Persons.ToListAsync();
        }

        public async Task<Person?> GetPersonById(Guid PersonId)
        {
            return await dbContext.Persons.FindAsync(PersonId);
        }

        public async Task AddPerson(Person person)
        {
            await dbContext.Persons.AddAsync(person);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdatePerson(Person person)
        {
            dbContext.Persons.Update(person);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeletePerson(Guid PersonId)
        {
            var person = await dbContext.Persons.FindAsync(PersonId);
            if (person != null)
            {
                dbContext.Persons.Remove(person);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}