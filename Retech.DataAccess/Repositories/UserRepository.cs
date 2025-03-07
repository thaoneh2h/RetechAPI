using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using Retech.DataAccess.DataContext;

namespace Retech.DataAccess.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.UserId == userId); // Tìm người dùng theo UserId
        }

        public async Task SaveAsync(User user)
        {
            _context.User.Update(user); // Cập nhật người dùng
            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            return await _context.User.Where(x => x.UserName == name).FirstOrDefaultAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }


    }

}
