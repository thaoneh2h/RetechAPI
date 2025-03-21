using Retech.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services
{
    public interface IOrderItemService
    {
        Task<OrderItemDTO> GetOrderItemByIdAsync(Guid orderItemId);
        Task<IEnumerable<OrderItemDTO>> GetOrderItemsByOrderIdAsync(Guid orderId);
        Task CreateOrderItemAsync(OrderItemDTO orderItemDto);
        Task UpdateOrderItemAsync(Guid orderItemId, OrderItemDTO orderItemDto);
        Task DeleteOrderItemAsync(Guid orderItemId);
    }
}
