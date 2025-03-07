using Retech.Core.Models;

namespace Retech.Application.Services
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
