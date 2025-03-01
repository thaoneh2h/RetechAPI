using RetechAPI.Models;

namespace RetechAPI.Services
{
    public interface IUserAddressService
    {
        Task<List<UserAddress>> GetUserAddressesAsync(Guid userId);
        Task<UserAddress> GetUserAddressAsync(Guid userAddressId);
        Task AddUserAddressAsync(UserAddress userAddress);
        Task UpdateUserAddressAsync(UserAddress userAddress);
        Task DeleteUserAddressAsync(Guid userAddressId);
    }
}
