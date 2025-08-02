using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.API.Data;
using SchoolManagementSystem.API.Interfaces;
using SchoolManagementSystem.API.Models;

namespace SchoolManagementSystem.API.Repositories
{
    // Data access logic are written here
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext dbContext;

        public StudentRepository(SchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await dbContext.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentById(Guid studentId)
        {
            return await dbContext.Students.FindAsync(studentId);
        }

        public async Task AddStudent(Student student)
        {
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            dbContext.Students.Update(student);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(Guid studentId)
        {
            var student = await dbContext.Students.FindAsync(studentId);
            if(student != null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}