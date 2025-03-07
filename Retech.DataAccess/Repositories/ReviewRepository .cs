using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using Retech.DataAccess.DataContext;

namespace Retech.DataAccess.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Review> AddReview(Review review)
        {
            _context.Review.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> GetReviewById(Guid reviewId)
        {
            return await _context.Review.FindAsync(reviewId);
        }

        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            return await _context.Review.ToListAsync();
        }
    }

}
