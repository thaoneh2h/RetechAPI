using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retech.Core.DTOS;
using Retech.Core.Models;


namespace Retech.Application.Services
{
    public interface ITransactionService
    {
        Task<Transaction> GetTransactionByIdAsync(Guid transactionId);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
        Task CreateTransactionAsync(TransactionDTO transactionDto);
        Task UpdateTransactionAsync(Guid transactionId, TransactionDTO transactionDto);
        Task DeleteTransactionAsync(Guid transactionId);
        Task ConfirmTransactionAsync(Guid transactionId);  // Xác nhận giao dịch
        Task CompleteTransactionAsync(Guid transactionId);  // Hoàn tất giao dịch
        Task CancelTransactionAsync(Guid transactionId);    // Hủy giao dịch
        Task<IEnumerable<TransactionDTO>> GetTransactionsByUserIdAsync(Guid userId);  // Lấy giao dịch của người dùng
    }
}
