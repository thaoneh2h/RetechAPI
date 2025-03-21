using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services;
using Retech.Core.DTOS;
using Retech.Core.Models;

namespace Retech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        // Get by TransactionId
        [HttpGet("{transactionId}")]
        public async Task<ActionResult<TransactionDTO>> GetTransactionById(Guid transactionId)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(transactionId);
            if (transaction == null)
                return NotFound();

            // Ánh xạ Transaction thành TransactionDTO trước khi trả về
            var transactionDto = _mapper.Map<TransactionDTO>(transaction);
            return Ok(transactionDto);
        }

        // Get all Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetAllTransactions()
        {
            var transactions = await _transactionService.GetAllTransactionsAsync();

            // Ánh xạ danh sách Transaction thành danh sách TransactionDTO
            var transactionDtos = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
            return Ok(transactionDtos);
        }

        // Create Transaction
        [HttpPost]
        public async Task<ActionResult> CreateTransaction([FromBody] TransactionDTO transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);  // Chuyển DTO sang Entity Model
            await _transactionService.CreateTransactionAsync(transactionDto);

            // Trả về TransactionDTO thay vì Transaction Entity
            var transactionResponse = _mapper.Map<TransactionDTO>(transaction);
            return CreatedAtAction(nameof(GetTransactionById), new { transactionId = transaction.TransactionId }, transactionResponse);
        }

        // Update Transaction
        [HttpPut("{transactionId}")]
        public async Task<ActionResult> UpdateTransaction(Guid transactionId, [FromBody] TransactionDTO transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto); // Ánh xạ DTO sang Model
            transaction.TransactionId = transactionId; // Đảm bảo TransactionId được giữ nguyên khi cập nhật

            await _transactionService.UpdateTransactionAsync(transactionId, transactionDto);
            return NoContent();
        }

        // Delete Transaction
        [HttpDelete("{transactionId}")]
        public async Task<ActionResult> DeleteTransaction(Guid transactionId)
        {
            await _transactionService.DeleteTransactionAsync(transactionId);
            return NoContent();
        }
        // Confirm Transaction (Người bán xác nhận)
        [HttpPut("confirm/{transactionId}")]
        public async Task<ActionResult> ConfirmTransaction(Guid transactionId)
        {
            await _transactionService.ConfirmTransactionAsync(transactionId);
            return NoContent();
        }

        // Complete Transaction (Hoàn tất giao dịch)
        [HttpPut("complete/{transactionId}")]
        public async Task<ActionResult> CompleteTransaction(Guid transactionId)
        {
            await _transactionService.CompleteTransactionAsync(transactionId);
            return NoContent();
        }

        // Cancel Transaction (Hủy giao dịch)
        [HttpPut("cancel/{transactionId}")]
        public async Task<ActionResult> CancelTransaction(Guid transactionId)
        {
            await _transactionService.CancelTransactionAsync(transactionId);
            return NoContent();
        }
        // Lấy lịch sử giao dịch của người dùng
        [HttpGet("history/{userId}")]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetTransactionHistory(Guid userId)
        {
            var transactions = await _transactionService.GetTransactionsByUserIdAsync(userId);
            if (transactions == null || !transactions.Any())
                return NotFound("No transactions found for this user.");

            return Ok(transactions);  // Trả về danh sách giao dịch của người dùng dưới dạng DTO
        }
    }
}