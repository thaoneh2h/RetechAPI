using AutoMapper;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.Core.Models.Enums;
using Retech.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Transaction> GetTransactionByIdAsync(Guid transactionId)
        {
            return await _transactionRepository.GetByIdAsync(transactionId);
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _transactionRepository.GetAllAsync();
        }

        public async Task CreateTransactionAsync(TransactionDTO transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto); // Ánh xạ từ TransactionDTO sang Transaction
            transaction.TransactionStatus = TransactionStatus.Processing;
            await _transactionRepository.AddAsync(transaction);
        }

        public async Task UpdateTransactionAsync(Guid transactionId, TransactionDTO transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto); // Ánh xạ từ TransactionDTO sang Transaction
            transaction.TransactionId = transactionId;  // Đảm bảo cập nhật đúng Transaction
            await _transactionRepository.UpdateAsync(transaction);
        }


        public async Task DeleteTransactionAsync(Guid transactionId)
        {
            await _transactionRepository.DeleteAsync(transactionId);
        }

        public async Task CompleteTransactionAsync(Guid transactionId)
        {
            var transaction = await _transactionRepository.GetByIdAsync(transactionId);
            if (transaction != null && transaction.TransactionStatus == TransactionStatus.Processing)
            {
                transaction.TransactionStatus = TransactionStatus.Completed;  // Cập nhật trạng thái giao dịch
                await _transactionRepository.UpdateAsync(transaction);
            }
        }

        public async Task CancelTransactionAsync(Guid transactionId)
        {
            var transaction = await _transactionRepository.GetByIdAsync(transactionId);
            if (transaction != null)
            {
                transaction.TransactionStatus = TransactionStatus.Canceled;  // Cập nhật trạng thái giao dịch
                await _transactionRepository.UpdateAsync(transaction);
            }
        }
        // Lấy giao dịch của người dùng
        public async Task<IEnumerable<TransactionDTO>> GetTransactionsByUserIdAsync(Guid userId)
        {
            var transactions = await _transactionRepository.GetTransactionsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<TransactionDTO>>(transactions);  // Ánh xạ từ Entity sang DTO
        }
    }
}
