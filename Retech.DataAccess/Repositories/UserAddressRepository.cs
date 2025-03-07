using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using Retech.DataAccess.DataContext;

namespace Retech.DataAccess.Repositories
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private readonly AppDbContext _context;

        public UserAddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserAddress>> GetUserAddressesAsync(Guid userId)
        {
            return await _context.UserAddresses
                .Where(address => address.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserAddress> GetUserAddressAsync(Guid userAddressId)
        {
            return await _context.UserAddresses
                .FirstOrDefaultAsync(address => address.UserAddressId == userAddressId);
        }

        public async Task AddUserAddressAsync(UserAddress userAddress)
        {
            await _context.UserAddresses.AddAsync(userAddress);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAddressAsync(UserAddress userAddress)
        {
            _context.UserAddresses.Update(userAddress);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAddressAsync(Guid userAddressId)
        {
            var address = await _context.UserAddresses
                .FirstOrDefaultAsync(a => a.UserAddressId == userAddressId);

            if (address != null)
            {
                _context.UserAddresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }
    }

}
