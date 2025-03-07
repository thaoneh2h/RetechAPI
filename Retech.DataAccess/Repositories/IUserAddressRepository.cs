using Retech.Core.Models;

namespace Retech.DataAccess.Repositories
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
