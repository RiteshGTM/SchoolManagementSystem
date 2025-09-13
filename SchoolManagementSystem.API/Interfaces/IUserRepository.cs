using SchoolManagementSystem.API.Models.Auth;

namespace SchoolManagementSystem.API.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync(User user);
        Task<IList<string>> GetRolesAsync(Guid userId);
        Task AddUserRoleAsync(Guid userId, Guid roleId);
        Task<Role?> GetRoleByNameAsync(string name);
        Task SaveChangesAsync();
    }
}
