using SchoolManagementSystem.API.DTOs;

namespace SchoolManagementSystem.API.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest req, string defaultRole = "Student");
        Task<AuthResponse> LoginAsync(LoginRequest req, string ipAddress);
        Task<AuthResponse?> RefreshAsync(string refreshToken, string ipAddress);
        Task RevokeRefreshTokenAsync(string refreshToken, string ipAddress);
    }
}
