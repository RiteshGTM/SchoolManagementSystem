using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.API.Models.Auth
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty; // e.g., Admin, Teacher, Student

        [MaxLength(200)]
        public string? Description { get; set; }

        // Navigation
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
