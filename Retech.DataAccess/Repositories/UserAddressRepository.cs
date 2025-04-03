using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using Retech.DataAccess.DataContext;
using Retech.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories;

public class UserAddressRepository : IUserAddressRepository
{
    private readonly AppDbContext _context;
    public UserAddressRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserAddress>> GetAllAsync()
        => await _context.UserAddresses.ToListAsync();

    public async Task<UserAddress> GetByIdAsync(Guid id)
        => await _context.UserAddresses.FindAsync(id);

    public async Task AddAsync(UserAddress address)
    {
        _context.UserAddresses.Add(address);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserAddress address)
    {
        _context.UserAddresses.Update(address);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var address = await _context.UserAddresses.FindAsync(id);
        if (address != null)
        {
            _context.UserAddresses.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}
