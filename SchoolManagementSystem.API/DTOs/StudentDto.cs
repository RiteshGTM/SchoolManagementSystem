namespace SchoolManagementSystem.API.DTOs
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        public string AdmissionNumber { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public int RollNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; }

    }
}
