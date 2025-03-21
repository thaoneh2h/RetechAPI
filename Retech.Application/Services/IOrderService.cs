using Retech.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> GetOrderByIdAsync(Guid orderId);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task CreateOrderAsync(OrderDTO orderDto);
        Task UpdateOrderAsync(Guid orderId, OrderDTO orderDto);
        Task DeleteOrderAsync(Guid orderId);
    }

}
