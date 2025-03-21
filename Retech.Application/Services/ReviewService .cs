using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.Repositories;


namespace Retech.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<ReviewDTO> AddReview(CreateReviewDTO createReviewDTO)
        {
            var review = new Review
            {
                ReviewerId = createReviewDTO.UserId,
                TransactionId = createReviewDTO.TransactionId,
                Comment = createReviewDTO.Comment,
                Rating = createReviewDTO.Rating,
                CreatedAt = DateTime.UtcNow
            };

            review = await _reviewRepository.AddReview(review);

            return new ReviewDTO
            {
                ReviewId = review.ReviewId,
                UserName = review.Reviewer.UserName,  // Assuming User is loaded
                Comment = review.Comment,
                Rating = review.Rating,
                CreatedAt = review.CreatedAt
            };
        }


        public async Task<ReviewDTO> GetReviewById(Guid reviewId)
        {
            var review = await _reviewRepository.GetReviewById(reviewId);

            return new ReviewDTO
            {
                ReviewId = review.ReviewId,
                UserName = review.Reviewer.UserName,  // Assuming User is loaded
                Comment = review.Comment,
                Rating = review.Rating,
                CreatedAt = review.CreatedAt
            };
        }
    }

}
