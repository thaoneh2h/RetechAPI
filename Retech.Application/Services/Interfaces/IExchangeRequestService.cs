using Retech.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services.Interfaces
{
    public interface IExchangeRequestService
    {
        Task CreateExchangeRequestAsync(CreateExchangeRequestDTO createExchangeRequestDTO);
        Task UpdateExchangeRequestStatusAsync(Guid exchangeRequestId, string status);
        Task<ExchangeRequestDTO> GetExchangeRequestByExchangeRequestIdAsync(Guid exchangeRequestId);
        Task UpdateExchangeRequestAsync(UpdateExchangeRequestDTO updateExchangeRequestDTO);

        Task<List<ExchangeRequestDTO>> GetExchangeRequestByUserResponseId(Guid userResponseId);
    }
}
