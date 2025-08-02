using SchoolManagementSystem.API.Interfaces;
using SchoolManagementSystem.API.Models;

namespace SchoolManagementSystem.API.Services
{
    // Business Logic are written here
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await studentRepository.GetAllStudents();
        }

        public async Task<Student> GetStudentById(Guid studentId)
        {
            return await studentRepository.GetStudentById(studentId);
        }

        public async Task AddStudent(Student student)
        {
            await studentRepository.AddStudent(student);
        }

        public async Task UpdateStudent(Student student)
        {
            await studentRepository.UpdateStudent(student);
        }

        public async Task DeleteStudent(Guid studentId)
        {
            await studentRepository.DeleteStudent(studentId);
        }
    }
}