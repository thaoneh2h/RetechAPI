using Retech.Core.Models;

namespace Retech.DataAccess.Repositories
{
    public interface IReviewRepository
    {
        Task<Review> AddReview(Review review);
        Task<Review> GetReviewById(Guid reviewId);
        Task<IEnumerable<Review>> GetAllReviews();
    }
}
