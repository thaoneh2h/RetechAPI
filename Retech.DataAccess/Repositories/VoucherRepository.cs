using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using Retech.Core.Models.Enums;
using Retech.DataAccess.DataContext;
using Retech.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly AppDbContext _context;

        public VoucherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Voucher> GetByIdAsync(Guid voucherId)
        {
            return await _context.Voucher
                .FirstOrDefaultAsync(v => v.VoucherId == voucherId);
        }

        public async Task<IEnumerable<Voucher>> GetAllByUserIdAsync(Guid userId)
        {
            return await _context.Voucher
                .Where(v => v.UserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(Voucher voucher)
        {
            await _context.Voucher.AddAsync(voucher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Voucher voucher)
        {
            _context.Voucher.Update(voucher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid voucherId)
        {
            var voucher = await _context.Voucher.FindAsync(voucherId);
            if (voucher != null)
            {
                _context.Voucher.Remove(voucher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Voucher> GetByVoucherCodeAsync(string voucherCode)
        {
            return await _context.Voucher
                .FirstOrDefaultAsync(v => v.VoucherCode == voucherCode);
        }

        public async Task<IEnumerable<Voucher>> GetAllActiveVouchersAsync()
        {
            return await _context.Voucher
                .Where(v => v.VoucherStatus == VoucherStatus.Active)
                .ToListAsync();
        }

        public async Task<IEnumerable<Voucher>> GetAllExpiredVouchersAsync()
        {
            return await _context.Voucher
                .Where(v => v.VoucherStatus == VoucherStatus.Expired)
                .ToListAsync();
        }
        public async Task<IEnumerable<Voucher>> GetAllAsync()
        {
            return await _context.Voucher
                .ToListAsync();  // Lấy tất cả các voucher
        }
    }
}
