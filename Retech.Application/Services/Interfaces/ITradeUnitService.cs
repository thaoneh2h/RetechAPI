using Retech.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services.Interfaces
{
    public interface ITradeUnitService
    {
        Task ProposeOrderAsync(OrderDTO orderDto);
        Task ApproveOrderAndCreateTransactionAsync(Guid orderId);
        Task CompleteTransactionAsync(Guid transactionId);
        Task CancelTransactionAsync(Guid transactionId);
    }
}
