using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Interfaces;
using SchoolManagementSystem.API.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [Authorize] // any logged-in user
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentById(Guid studentId)
        {
            var student = await studentService.GetStudentById(studentId);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            await studentService.AddStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentId }, student);
            // CreatedAtAction = “I’ve created something, and here’s where you can find it.”
        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> UpdateStudent(Guid studentId ,Student student)
        {
            if (studentId != student.StudentId) return BadRequest();
            await studentService.UpdateStudent(student);
            return NoContent();
        }

        [Authorize(Roles = "Admin")] // only Admin role
        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            await studentService.DeleteStudent(studentId);
            return NoContent();
        }
    }
}