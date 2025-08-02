using SchoolManagementSystem.API.Models;

namespace SchoolManagementSystem.API.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();

        Task<Student> GetStudentById(Guid studentId);

        Task AddStudent(Student student);

        Task UpdateStudent(Student student);

        Task DeleteStudent(Guid studentId);
    }
}