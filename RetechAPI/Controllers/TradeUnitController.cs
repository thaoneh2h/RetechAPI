using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;

namespace Retech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeUnitController : ControllerBase
    {
        private readonly ITradeUnitService _tradeUnitService;

        public TradeUnitController(ITradeUnitService tradeUnitService)
        {
            _tradeUnitService = tradeUnitService;
        }

        [HttpPost("propose-order")]
        public async Task<IActionResult> ProposeOrder([FromBody] OrderDTO orderDto)
        {
            await _tradeUnitService.ProposeOrderAsync(orderDto);
            return Ok(new { message = "Order proposed successfully." });
        }

        [HttpPut("approve-order/{orderId}")]
        public async Task<IActionResult> ApproveOrder(Guid orderId)
        {
            await _tradeUnitService.ApproveOrderAndCreateTransactionAsync(orderId);
            return Ok(new { message = "Order approved and transaction created." });
        }

        [HttpPut("complete-transaction/{transactionId}")]
        public async Task<IActionResult> CompleteTransaction(Guid transactionId)
        {
            await _tradeUnitService.CompleteTransactionAsync(transactionId);
            return Ok(new { message = "Transaction and order marked as completed." });
        }

        [HttpPut("cancel-transaction/{transactionId}")]
        public async Task<IActionResult> CancelTransaction(Guid transactionId)
        {
            await _tradeUnitService.CancelTransactionAsync(transactionId);
            return Ok(new { message = "Transaction canceled and stock restored." });
        }
    }
}
