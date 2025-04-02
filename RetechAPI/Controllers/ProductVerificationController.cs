using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.Service;

namespace Retech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVerificationController : ControllerBase
    {
        private readonly IProductVerificationService _productVerificationService;

        public ProductVerificationController(IProductVerificationService productVerificationService)
        {
            _productVerificationService = productVerificationService;
        }

        // API to schedule a product verification by the seller
        [HttpPost("schedule")]
        public async Task<ActionResult> ScheduleVerification([FromBody] DeviceVerificationFormDTO verificationRequest)
        {
            // Call the service to handle scheduling the verification
            var request = await _productVerificationService.ScheduleVerificationAsync(verificationRequest);
            // Return CreatedAtAction with the correct route and productId (since ProductVerification has ProductId)
            return CreatedAtAction(nameof(GetVerificationResult), new { productId = request.ProductId }, request);
        }

        // API to complete the verification (done by staff)
        [HttpPut("complete/{productId}")]
        public async Task<ActionResult> CompleteVerification(Guid productId, [FromBody] ProductVerificationDTO verificationResult)
        {
            try
            {
                // Call service to complete the verification
                await _productVerificationService.CompleteVerificationAsync(productId, verificationResult);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // API to get the verification result of a product
        [HttpGet("result/{productId}")]
        public async Task<ActionResult<ProductVerificationDTO>> GetVerificationResult(Guid productId)
        {
            // Get verification result from service
            var result = await _productVerificationService.GetVerificationResultAsync(productId);

            // If result is not found, return NotFound
            if (result == null)
                return NotFound();

            // Return the verification result
            return Ok(result);
        }
        [HttpGet("DeviceVerificationForm")]
        public async Task<ActionResult<IEnumerable<DeviceVerificationFormDTO>>> GetAllDeviceVerificationForm()
        {
            var deviceVerificationForm = await _productVerificationService.GetAllDeviceVerificationFormAsync();
            return Ok(deviceVerificationForm);
        }
        [HttpGet("ProductVerification")]
        public async Task<ActionResult<IEnumerable<ProductVerificationDTO>>> GetAllProductVerification()
        {
            var verification = await _productVerificationService.GetAllProductVerificationAsync();
            return Ok(verification);
        }
    }


}
