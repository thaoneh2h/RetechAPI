using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using Retech.DataAccess.DataContext;
using Retech.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Review> GetByIdAsync(Guid id)
        {
            return await _context.Review
                .Include(r => r.Reviewer)
                .Include(r => r.Reviewee)
                .FirstOrDefaultAsync(r => r.ReviewId == id);
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Review
                .Include(r => r.Reviewer)
                .Include(r => r.Reviewee)
                .ToListAsync();
        }

        public async Task AddAsync(Review review)
        {
            await _context.Review.AddAsync(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Review review)
        {
            _context.Review.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var review = await _context.Review.FindAsync(id);
            if (review == null) return false;

            _context.Review.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsForOrderAsync(Guid orderId)
        {
            return await _context.Review.AnyAsync(r => r.OrderId == orderId);
        }
    }
}
