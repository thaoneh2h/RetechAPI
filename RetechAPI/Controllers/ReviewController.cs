using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;
using System.Security.Claims;

namespace Retech.API.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReviewController(
            IReviewService reviewService,
            IHttpContextAccessor httpContextAccessor)
        {
            _reviewService = reviewService;
            _httpContextAccessor = httpContextAccessor;
        }

        private Guid GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.Parse(userId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewService.GetAllAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null) return NotFound();
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReviewDTO dto)
        {
            try
            {
                var userId = GetCurrentUserId();
                var review = await _reviewService.CreateAsync(userId, dto);
                return CreatedAtAction(nameof(GetById), new { id = review.ReviewId }, review);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateReviewDTO dto)
        {
            try
            {
                var userId = GetCurrentUserId();
                var review = await _reviewService.UpdateAsync(id, userId, dto);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var userId = GetCurrentUserId();
                var result = await _reviewService.DeleteAsync(id, userId);
                if (!result) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
