using Retech.Core.Models;
using Microsoft.EntityFrameworkCore;
using Retech.DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> GetByIdAsync(Guid transactionId)
        {
            return await _context.Transaction
                .Include(t => t.Buyer)
                .Include(t => t.Seller)
                .Include(t => t.Product)
                .Include(t => t.EWallet)
                .FirstOrDefaultAsync(t => t.TransactionId == transactionId);
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transaction
                .Include(t => t.Buyer)
                .Include(t => t.Seller)
                .Include(t => t.Product)
                .Include(t => t.EWallet)
                .ToListAsync();
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transaction.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _context.Transaction.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid transactionId)
        {
            var transaction = await _context.Transaction.FindAsync(transactionId);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Transaction>> GetTransactionsByUserIdAsync(Guid userId)
        {
            return await _context.Transaction
                .Where(t => t.BuyerId == userId || t.SellerId == userId)  // Lọc theo BuyerId hoặc SellerId
                .Include(t => t.Product)
                .Include(t => t.Buyer)
                .Include(t => t.Seller)
                .ToListAsync();
        }
    }
}
