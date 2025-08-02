using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.API.Models
{
    [Table("Sections")]
    public class Section
    {
        [Key]
        [Column("SectionId", TypeName = "UNIQUEIDENTIFIER")]
        [Display(Name = "Section Id", Description = "Section Id")]
        public Guid SectionId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("SectionName")]
        [Display(Name = "Section Name", Description = "Section Name")]
        public string SectionName { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Class")]
        [Column("ClassId", TypeName = "UNIQUEIDENTIFIER")]
        [Display(Name = "Class Id", Description = "Class Id")]
        public Guid ClassId { get; set; }

        [Required]
        [Column("Capacity")]
        [Display(Name = "Capacity", Description = "Capacity")]
        public int Capacity { get; set; }

        [MaxLength(20)]
        [Column("RoomNumber")]
        [Display(Name = "Room Number", Description = "Room Number")]
        public string? RoomNumber { get; set; }

        [Required]
        [Column("IsActive")]
        [Display(Name = "Is Active", Description = "Is Active")]
        public bool IsActive { get; set; } = true;

        [Required]
        [Column("CreatedAt")]
        [Display(Name = "Created At", Description = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("UpdatedAt")]
        [Display(Name = "Updated At", Description = "Updated At")]
        public DateTime UpdatedAt { get; set; }
    }
}