using Retech.Core.DTOS;
using Retech.Core.Models;

namespace Retech.Application.Services;

public interface IAdminService
{
    Task<IEnumerable<User>> GetAllUsersAsync(string? role = null);
    Task<User> GetUserByIdAsync(Guid userId);
    Task<User> CreateUserAsync(User user);
    Task<User> UpdateUserAsync(Guid userId, User updatedUser);
    Task<bool> DeleteUserAsync(Guid userId);
}
