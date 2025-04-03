using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;

namespace Retech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        // Tạo ví mới cho người dùng (chỉ cần UserId)
        [HttpPost]
        public async Task<ActionResult> CreateWallet([FromBody] E_WalletDTO walletDto)
        {
            await _walletService.AddWalletAsync(walletDto);
            return CreatedAtAction(nameof(GetWalletByUserId), new { userId = walletDto.UserId }, walletDto);
        }

        // Lấy ví theo ID
        [HttpGet("{walletId}")]
        public async Task<ActionResult<ResponseWalletDTO>> GetWallet(Guid walletId)
        {
            var wallet = await _walletService.GetWalletByIdAsync(walletId);
            if (wallet == null) return NotFound();
            return Ok(wallet);
        }

        // Lấy ví của người dùng theo UserId
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ResponseWalletDTO>> GetWalletByUserId(Guid userId)
        {
            var wallet = await _walletService.GetWalletByUserIdAsync(userId);
            if (wallet == null) return NotFound();
            return Ok(wallet);
        }

        // Lấy tất cả ví
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseWalletDTO>>> GetAllWallets()
        {
            var wallets = await _walletService.GetAllWalletsAsync();
            return Ok(wallets);
        }

        // Cập nhật ví
        [HttpPut("{walletId}")]
        public async Task<ActionResult> UpdateWallet(Guid walletId, [FromBody] ResponseWalletDTO walletDto)
        {
            await _walletService.UpdateWalletAsync(walletId, walletDto);
            return NoContent();
        }

        // Xóa ví
        [HttpDelete("{walletId}")]
        public async Task<ActionResult> DeleteWallet(Guid walletId)
        {
            await _walletService.DeleteWalletAsync(walletId);
            return NoContent();
        }
    }

}
