using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using Retech.DataAccess.DataContext;
using Retech.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly AppDbContext _context;

        public WalletRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<E_Wallet> GetByIdAsync(Guid walletId)
        {
            return await _context.EWallet
                .FirstOrDefaultAsync(w => w.WalletId == walletId);
        }

        public async Task<E_Wallet> GetByUserIdAsync(Guid userId)
        {
            return await _context.EWallet
                .FirstOrDefaultAsync(w => w.UserId == userId);  // Mỗi người dùng chỉ có một ví
        }

        public async Task<IEnumerable<E_Wallet>> GetAllAsync()
        {
            return await _context.EWallet.ToListAsync();  // Lấy tất cả các ví
        }

        public async Task AddAsync(E_Wallet wallet)
        {
            await _context.EWallet.AddAsync(wallet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(E_Wallet wallet)
        {
            _context.EWallet.Update(wallet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid walletId)
        {
            var wallet = await _context.EWallet.FindAsync(walletId);
            if (wallet != null)
            {
                _context.EWallet.Remove(wallet);
                await _context.SaveChangesAsync();
            }
        }
    }
}
