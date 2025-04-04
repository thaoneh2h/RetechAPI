using Retech.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories.Interfaces
{
    public interface IExchangeRequestRepository
    {
        Task AddAsync(ExchangeRequest exchangeRequest);
        Task<ExchangeRequest?> GetByIdAsync(Guid exchangeRequest);
        void UpdateAsync(ExchangeRequest exchangeRequest);
        Task<bool> CheckIsProcessing(Guid UserOfferId, Guid UserResponseId);
        Task<List<ExchangeRequest>> GetExchangeRequestsByUserResponseId(Guid userResponseId);
    }
}
