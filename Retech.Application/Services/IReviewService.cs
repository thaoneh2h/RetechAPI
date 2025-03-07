using Retech.Core.DTOS;

namespace Retech.Application.Services
{
    public interface IReviewService
    {
        Task<ReviewDTO> AddReview(CreateReviewDTO createReviewDTO);
        Task<ReviewDTO> GetReviewById(Guid reviewId);
    }
}
