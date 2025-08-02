using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.API.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [Column("StudentId", TypeName = "UNIQUEIDENTIFIER")]
        [Display(Name = "Student Id", Description = "Student Id")]
        public Guid StudentId { get; set; }

        [Required]
        [ForeignKey("Person")]
        [Column("PersonId", TypeName = "UNIQUEIDENTIFIER")]
        [Display(Name = "Person Id", Description = "Person Id")]
        public Guid PersonId { get; set; }

        [Required]
        [Column("AdmissionNumber")]
        [MaxLength(30)]
        [Display(Name = "Admission Number", Description = "Admission Number")]
        public string AdmissionNumber { get; set; }

        [Required]
        [Column("ClassName")]
        [MaxLength(100)]
        [Display(Name = "Class Name", Description = "Class Name")]
        public string ClassName { get; set; }

        [Required]
        [Column("SectionName")]
        [MaxLength(50)]
        [Display(Name = "Section Name", Description = "Section Name")]
        public string SectionName { get; set; }

        [Required]
        [Column("RollNumber")]
        [Display(Name = "Roll Number", Description = "Roll Number")]
        public int RollNumber { get; set; }

        [Required]
        [Column("EnrollmentDate", TypeName = "DATE")]
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date", Description = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        [Column("IsActive")]
        [Display(Name = "Is Active", Description = "Is Active")]
        public bool IsActive { get; set; } = true;
    }
}