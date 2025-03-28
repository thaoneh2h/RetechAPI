using Retech.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services.Interfaces
{
    public interface IOrderService
    {
        // Get a specific order by its ID
        Task<OrderDTO> GetOrderByIdAsync(Guid orderId);

        // Get all orders (can be filtered later in implementation)
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();

        // Create a new order with the given details (validates product type and adds OrderItem)
        Task CreateOrderAsync(OrderDTO orderDto);

        // Update an existing order
        Task UpdateOrderAsync(Guid orderId, OrderDTO orderDto);

        // Delete an order by its ID
        Task DeleteOrderAsync(Guid orderId);

        // Propose an order, ensuring only products with 'Selling' status can be ordered
        Task ProposeOrderAsync(OrderDTO orderDto);

        // Approve the order after validation (only 'Selling' products)
        Task ApproveOrderAsync(Guid orderId);

        // Cancel an existing order (can only cancel 'Selling' products)
        Task CancelOrderAsync(Guid orderId);

        // Complete an order (ensures all items are 'Selling')
        Task CompleteOrderAsync(Guid orderId);
    }

}
