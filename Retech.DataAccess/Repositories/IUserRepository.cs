using Retech.Core.Models;

namespace Retech.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid userId); // Lấy người dùng theo Id
        Task SaveAsync(User user); // Lưu thay đổi vào cơ sở dữ liệu
        //CRUD
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByNameAsync(string name);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);






    }
}
