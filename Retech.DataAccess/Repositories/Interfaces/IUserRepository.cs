using Retech.Core.Models;

namespace Retech.DataAccess.Repositories.Interfaces;

public interface IUserRepository 
{
    Task AddAsync(User user);
    Task<User> GetByEmailAsync(string email);
}
