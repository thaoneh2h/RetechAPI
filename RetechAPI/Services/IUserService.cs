using RetechAPI.DTOS;
using RetechAPI.Models;
using System.Threading.Tasks;

namespace RetechAPI.Services
{
    public interface IUserService
    {
        Task<UserProfileDTO> GetUserProfileAsync(Guid userId); // Xem hồ sơ người dùng
        Task UpdateUserProfileAsync(Guid userId, UserProfileDTO userProfileDTO); // Cập nhật hồ sơ người dùng

        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByNameAsync(string name);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);




    }
}
