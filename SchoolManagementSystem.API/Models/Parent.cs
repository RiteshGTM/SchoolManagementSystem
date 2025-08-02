using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.API.Models
{
    [Table("Parents")]
    public class Parent
    {
        [Key]
        [Column("ParentId", TypeName = "UNIQUEIDENTIFIER")]
        [Display(Name = "Parent Id", Description = "Parent Id")]
        public Guid ParentId { get; set; }

        [Required]
        [ForeignKey("Person")]
        [Column("PersonId", TypeName = "UNIQUEIDENTIFIER")]
        [Display(Name = "Person Id", Description = "Person Id")]
        public Guid PersonId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("RelationshipType")]
        [Display(Name = "Relationship Type", Description = "Relationship Type")]
        public string RelationshipType { get; set; }

        [MaxLength(100)]
        [Column("Occupation")]
        [Display(Name = "Occupation", Description = "Occupation")]
        public string? Occupation { get; set; }

        [Column("AnnualIncome", TypeName = "DECIMAL(18,2)")]
        [Display(Name = "Annual Income", Description = "Annual Income")]
        public decimal? AnnualIncome { get; set; }

        [Required]
        [Column("IsEmergencyContact")]
        [Display(Name = "Is Emergency Contact", Description = "Is Emergency Contact")]
        public bool IsEmergencyContact { get; set; }
    }
}
