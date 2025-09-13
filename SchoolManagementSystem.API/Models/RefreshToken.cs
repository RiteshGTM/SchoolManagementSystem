using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.API.Models.Auth
{
    [Table("RefreshTokens")]
    public class RefreshToken
    {
        [Key]
        public Guid RefreshTokenId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required, MaxLength(300)]
        public string Token { get; set; } = string.Empty;

        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedByIp { get; set; }
        public DateTime? RevokedAt { get; set; }
        public string? ReplacedByToken { get; set; }

        // It doesn’t store data in the database — it just returns true or false based on the token’s state.
        public bool IsActive => RevokedAt == null && DateTime.UtcNow <= ExpiresAt;

        // Navigation
        public User User { get; set; } = null!;
    }
}
