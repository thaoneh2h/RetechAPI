using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;

namespace Retech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;

        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateVoucher([FromBody] VoucherDTO voucherDto)
        {
            await _voucherService.AddVoucherAsync(voucherDto);
            return CreatedAtAction(nameof(GetVoucher), new { voucherId = voucherDto.VoucherId }, voucherDto);
        }

        [HttpGet("{voucherId}")]
        public async Task<ActionResult<ResponseVoucherDTO>> GetVoucher(Guid voucherId)
        {
            var voucher = await _voucherService.GetVoucherByIdAsync(voucherId);
            if (voucher == null) return NotFound();
            return Ok(voucher);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseVoucherDTO>>> GetAllVouchers()
        {
            var vouchers = await _voucherService.GetAllVouchersAsync();
            return Ok(vouchers);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<ResponseVoucherDTO>>> GetAllActiveVouchers()
        {
            var vouchers = await _voucherService.GetAllActiveVouchersAsync();
            return Ok(vouchers);
        }

        [HttpGet("expired")]
        public async Task<ActionResult<IEnumerable<ResponseVoucherDTO>>> GetAllExpiredVouchers()
        {
            var vouchers = await _voucherService.GetAllExpiredVouchersAsync();
            return Ok(vouchers);
        }

        [HttpPut("{voucherId}")]
        public async Task<ActionResult> UpdateVoucher(Guid voucherId, [FromBody] VoucherDTO voucherDto)
        {
            await _voucherService.UpdateVoucherAsync(voucherId, voucherDto);
            return NoContent();
        }

        [HttpPut("update-status/{voucherId}")]
        public async Task<ActionResult> UpdateVoucherStatus(Guid voucherId)
        {
            await _voucherService.UpdateVoucherStatusAsync(voucherId);
            return NoContent();
        }

        [HttpDelete("{voucherId}")]
        public async Task<ActionResult> DeleteVoucher(Guid voucherId)
        {
            await _voucherService.DeleteVoucherAsync(voucherId);
            return NoContent();
        }
    }

}
