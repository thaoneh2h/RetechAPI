using RetechAPI.Models;

namespace RetechAPI.Repositories
{
    public interface IUserAddressRepository
    {
        Task<List<UserAddress>> GetUserAddressesAsync(Guid userId);
        Task<UserAddress> GetUserAddressAsync(Guid userAddressId);
        Task AddUserAddressAsync(UserAddress userAddress);
        Task UpdateUserAddressAsync(UserAddress userAddress);
        Task DeleteUserAddressAsync(Guid userAddressId);
    }

}
