using Retech.Core.Models;
using Retech.DataAccess.Repositories;

namespace Retech.Application.Services
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IUserAddressRepository _userAddressRepository;

        public UserAddressService(IUserAddressRepository userAddressRepository)
        {
            _userAddressRepository = userAddressRepository;
        }

        public async Task<List<UserAddress>> GetUserAddressesAsync(Guid userId)
        {
            return await _userAddressRepository.GetUserAddressesAsync(userId);
        }

        public async Task<UserAddress> GetUserAddressAsync(Guid userAddressId)
        {
            return await _userAddressRepository.GetUserAddressAsync(userAddressId);
        }

        public async Task AddUserAddressAsync(UserAddress userAddress)
        {
            await _userAddressRepository.AddUserAddressAsync(userAddress);
        }

        public async Task UpdateUserAddressAsync(UserAddress userAddress)
        {
            await _userAddressRepository.UpdateUserAddressAsync(userAddress);
        }

        public async Task DeleteUserAddressAsync(Guid userAddressId)
        {
            await _userAddressRepository.DeleteUserAddressAsync(userAddressId);
        }
    }

}
