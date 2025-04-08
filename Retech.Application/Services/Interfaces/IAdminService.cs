using Retech.Core.DTOS;
using Retech.Core.Models;

namespace Retech.Application.Services;

public interface IAdminService
{
    Task<IEnumerable<UserDTO>> GetAllUsersAsync(string? role = null);
    Task<UserDTO> GetUserByIdAsync(Guid userId);
    Task<UserDTO> CreateUserAsync(CreateUserDTO userDto);
    Task<UserDTO> UpdateUserAsync(Guid userId, UpdateUserDTO updatedUserDto);
    Task<bool> DeleteUserAsync(Guid userId);
}
