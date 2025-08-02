using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace SchoolManagementSystem.API.Models
{
    [Table("Classes")]
    public class Class
    {
        [Key]
        [Column("ClassId", TypeName = "UNIQUEIDENTIFIER")]
        [Display(Name = "Class Id", Description = "Class Id")]
        public Guid ClassId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("ClassName")]
        [Display(Name = "Class Name", Description = "Class Name")]
        public string ClassName { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Column("ClassCode")]
        [Display(Name = "Class Code", Description = "Class Code")]
        public string ClassCode { get; set; } = string.Empty;

        [Required]
        [Column("CreatedAt")]
        [Display(Name = "Created At", Description = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("UpdatedAt")]
        [Display(Name = "Updated At", Description = "Updated At")]
        public DateTime UpdatedAt { get; set; }

        [Required]
        [Column("IsActive")]
        [Display(Name = "Is Active", Description = "Is Active")]
        public bool IsActive { get; set; } = true;
    }
}