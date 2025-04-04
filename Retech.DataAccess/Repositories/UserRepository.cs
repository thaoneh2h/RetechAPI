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
        .Where(u => u.Email == email)
        .Select(u => new User
        {
            UserId = u.UserId,
            Email = u.Email,
            Password = u.Password,
            UserRole = u.UserRole,
            UserName = u.UserName,
            PhoneNumber = u.PhoneNumber,
            Address = u.Address,
            Gender = u.Gender,
            BirthDate = u.BirthDate,
            ProfilePicture = u.ProfilePicture,
            RegistrationDate = u.RegistrationDate,
            UserStatus = u.UserStatus,
            Rating = u.Rating,
            KycVerified = u.KycVerified
        })
        .AsNoTracking()
        .FirstOrDefaultAsync();
    }
}

