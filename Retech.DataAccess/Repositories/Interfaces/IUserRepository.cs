using Retech.Core.Models;

namespace Retech.DataAccess.Repositories.Interfaces;

public interface IUserRepository 
{
    Task AddAsync(User user);
    Task<User> GetByEmailAsync(string email);
    Task<User> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task UpdateAsync(User user);
    Task<bool> DeleteAsync(Guid id);
}
