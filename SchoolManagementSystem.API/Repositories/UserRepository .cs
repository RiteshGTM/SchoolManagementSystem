using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.API.Data;
using SchoolManagementSystem.API.Interfaces;
using SchoolManagementSystem.API.Models.Auth;

namespace SchoolManagementSystem.API.Repositories
{
    public class UserRepository : IUserRepository // AuthRepository another name can also
    {
        private readonly SchoolDbContext _db;

        public UserRepository(SchoolDbContext db) => _db = db;

        public Task<User?> GetByEmailAsync(string email) =>
            _db.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                     .FirstOrDefaultAsync(u => u.Email == email);

        public Task<User?> GetByIdAsync(Guid id) =>
            _db.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                     .FirstOrDefaultAsync(u => u.UserId == id);

        public async Task AddAsync(User user) => await _db.Users.AddAsync(user);

        public async Task<IList<string>> GetRolesAsync(Guid userId) =>
            await _db.UserRoles.Where(ur => ur.UserId == userId)
                               .Select(ur => ur.Role.Name)
                               .ToListAsync();

        public Task<Role?> GetRoleByNameAsync(string name) =>
            _db.Roles.FirstOrDefaultAsync(r => r.Name == name);

        public async Task AddUserRoleAsync(Guid userId, Guid roleId)
        {
            await _db.UserRoles.AddAsync(new UserRole { UserId = userId, RoleId = roleId });
        }

        public Task SaveChangesAsync() => _db.SaveChangesAsync();
    }
}