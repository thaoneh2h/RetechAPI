using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using Retech.DataAccess.DataContext;
using Retech.DataAccess.Repositories.Interfaces;

namespace Retech.DataAccess.Repositories.Implementations;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.User.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _context.User
        .AsNoTracking()
        .FirstOrDefaultAsync(u => u.Email == email);
    }
}

