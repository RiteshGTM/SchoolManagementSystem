using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.API.Models
{
    [Table("Teachers")]
    public class Teacher
    {
        [Key]
        [Column("TeacherId", TypeName = "UNIQUEIDENTIFIER")]
        [Display(Name = "Teacher Id", Description = "Teacher Id")]
        public Guid TeacherId { get; set; }

        [Required]
        [ForeignKey("Person")]
        [Column("PersonId", TypeName = "UNIQUEIDENTIFIER")]
        [Display(Name = "Person Id", Description = "Person Id")]
        public Guid PersonId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("EmployeeCode")]
        [Display(Name = "Employee Code", Description = "Employee Code")]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("Qualification")]
        [Display(Name = "Qualification", Description = "Qualification")]
        public string Qualification { get; set; } = string.Empty;

        [MaxLength(100)]
        [Column("Specialization")]
        [Display(Name = "Specialization", Description = "Specialization")]
        public string? Specialization { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column("HireDate", TypeName = "DATE")]
        [Display(Name = "Hire Date", Description = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Required]
        [Column("IsActive")]
        [Display(Name = "Is Active", Description = "Is Active")]
        public bool IsActive { get; set; } = true;
    }
}
