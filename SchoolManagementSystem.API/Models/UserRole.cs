using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.API.Models.Auth
{
    [Table("UserRoles")]
    public class UserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        // Navigation
        public User User { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}
