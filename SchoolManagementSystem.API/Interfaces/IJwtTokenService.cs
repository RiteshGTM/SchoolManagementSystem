using SchoolManagementSystem.API.Models.Auth;

namespace SchoolManagementSystem.API.Interfaces
{
    public interface IJwtTokenService
    {
        (string token, DateTime expiresAt) GenerateAccessToken(User user, IEnumerable<string> roles);
        string GenerateRefreshToken();
    }
}
