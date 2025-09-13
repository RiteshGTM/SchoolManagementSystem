using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.API.Interfaces;
using SchoolManagementSystem.API.Models.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolManagementSystem.API.Services
{
    /*
    ✅ In Simple Words

    This method:

    1.	Reads config (Issuer, Audience, Secret, Expiry).
    2.	Creates a secure signing key.
    3.	Packs user info (claims) + roles into the token.
    4.	Sets an expiry time.
    5.	Signs it with secret key.
    6.	Returns the final JWT string + expiry time.

    👉 Access Token = a digitally signed ID card that proves who you are and what role you have.
     */

    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _config;

        public JwtTokenService(IConfiguration config) => _config = config;

        public (string token, DateTime expiresAt) GenerateAccessToken(User user, IEnumerable<string> roles)
        {
            var cfg = _config.GetSection("Jwt"); // Get JWT settings from appsettings.json
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg["Key"]!));  // like stamping the token with a unique seal.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);   // like stamping the token with a unique seal.

            var claims = new List<Claim>
            {
            new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new(ClaimTypes.Name, user.Email),
            new(ClaimTypes.Email, user.Email)
            };
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var expires = DateTime.UtcNow.AddMinutes(int.Parse(cfg["AccessTokenMinutes"]!));

            var token = new JwtSecurityToken(
                issuer: cfg["Issuer"],
                audience: cfg["Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), expires);
        }

        public string GenerateRefreshToken()
        {
            // 64 random bytes = a long and unique string.
            var bytes = new byte[64]; 

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes); // Generates cryptographically secure random bytes (much stronger than Random).
            // Prevents attackers from guessing refresh tokens.

            // That’s the actual refresh token the client receives and later sends back for refreshing access tokens.
            return Convert.ToBase64String(bytes);
        }
    }
}