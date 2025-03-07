using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services;
using Retech.Core.DTOS;

namespace Retech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] CreateReviewDTO createReviewDto)
        {
            var review = await _reviewService.AddReview(createReviewDto);
            return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(Guid id)
        {
            var review = await _reviewService.GetReviewById(id);
            if (review == null) return NotFound();
            return Ok(review);
        }
    }

}
