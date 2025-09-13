using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.API.Data;
using SchoolManagementSystem.API.DTOs;
using SchoolManagementSystem.API.Interfaces;
using SchoolManagementSystem.API.Models.Auth;

namespace SchoolManagementSystem.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly SchoolDbContext _db;

        private readonly IUserRepository _users;
        private readonly IJwtTokenService _jwt;

        private readonly IConfiguration _cfg;

        public AuthService(IUserRepository users, IJwtTokenService jwt, SchoolDbContext db, IConfiguration cfg)
        {
            _users = users; _jwt = jwt; _db = db; _cfg = cfg;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest req, string defaultRole = "Student")
        {
            var existing = await _users.GetByEmailAsync(req.Email);
            if (existing != null) throw new ApplicationException("Email already in use.");

            var user = new User
            {
                UserId = Guid.NewGuid(),
                Email = req.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password),
                IsActive = true
            };

            await _users.AddAsync(user);

            // Ensure default role exists
            var role = await _users.GetRoleByNameAsync(defaultRole);
            if (role == null)  // If role not found, create it
            {
                role = new Role { RoleId = Guid.NewGuid(), Name = defaultRole, Description = "Default role" };
                _db.Roles.Add(role);
            }
            await _users.AddUserRoleAsync(user.UserId, role.RoleId);

            await _users.SaveChangesAsync();

            var roles = await _users.GetRolesAsync(user.UserId);
            var (token, expires) = _jwt.GenerateAccessToken(user, roles);

            var rt = CreateRefreshToken(user.UserId);
            _db.RefreshTokens.Add(rt);
            await _db.SaveChangesAsync();

            return new AuthResponse { AccessToken = token, ExpiresAt = expires, RefreshToken = rt.Token };
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest req, string ipAddress)
        {
            var user = await _users.GetByEmailAsync(req.Email);
            if (user == null || !user.IsActive || !BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash))
                throw new ApplicationException("Invalid credentials.");

            user.LastLoginAt = DateTime.UtcNow;

            var roles = await _users.GetRolesAsync(user.UserId);
            var (token, expires) = _jwt.GenerateAccessToken(user, roles);

            var rt = CreateRefreshToken(user.UserId, ipAddress);
            _db.RefreshTokens.Add(rt);
            await _db.SaveChangesAsync();

            return new AuthResponse { AccessToken = token, ExpiresAt = expires, RefreshToken = rt.Token };
        }

        public async Task<AuthResponse?> RefreshAsync(string refreshToken, string ipAddress)
        {
            var existing = await _db.RefreshTokens
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Token == refreshToken);

            if (existing == null || !existing.IsActive) return null;

            existing.RevokedAt = DateTime.UtcNow;
            existing.ReplacedByToken = "rotated";

            var roles = await _users.GetRolesAsync(existing.UserId);
            var (token, expires) = _jwt.GenerateAccessToken(existing.User, roles);

            var newRt = CreateRefreshToken(existing.UserId, ipAddress);
            _db.RefreshTokens.Add(newRt);

            await _db.SaveChangesAsync();

            return new AuthResponse { AccessToken = token, ExpiresAt = expires, RefreshToken = newRt.Token };
        }

        public async Task RevokeRefreshTokenAsync(string refreshToken, string ipAddress)
        {
            var rt = await _db.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken);
            if (rt != null && rt.IsActive)
            {
                rt.RevokedAt = DateTime.UtcNow;
                rt.ReplacedByToken = "revoked";
                await _db.SaveChangesAsync();
            }
        }

        private RefreshToken CreateRefreshToken(Guid userId, string? ip = null)
        {
            var days = int.Parse(_cfg["Jwt:RefreshTokenDays"]!); // Means refresh token will expire in 7 days (or whatever you set).
            
            return new RefreshToken // mapping with database table
            {
                RefreshTokenId = Guid.NewGuid(),
                UserId = userId,
                Token = _jwt.GenerateRefreshToken(),
                ExpiresAt = DateTime.UtcNow.AddDays(days),
                CreatedAt = DateTime.UtcNow,
                CreatedByIp = ip
            };
        }
    }
}
