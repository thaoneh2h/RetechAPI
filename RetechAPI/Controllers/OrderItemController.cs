using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;

namespace Retech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        // Get by OrderItemId
        [HttpGet("{orderItemId}")]
        public async Task<ActionResult<OrderItemDTO>> GetOrderItemById(Guid orderItemId)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdAsync(orderItemId);
            if (orderItem == null)
                return NotFound();
            return Ok(orderItem);
        }

        // Get by OrderId
        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderItemDTO>>> GetOrderItemsByOrderId(Guid orderId)
        {
            var orderItems = await _orderItemService.GetOrderItemsByOrderIdAsync(orderId);
            return Ok(orderItems);
        }

        // Create OrderItem
        [HttpPost]
        public async Task<ActionResult> CreateOrderItem([FromBody] OrderItemDTO orderItemDto)
        {
            await _orderItemService.CreateOrderItemAsync(orderItemDto);
            return CreatedAtAction(nameof(GetOrderItemById), new { orderItemId = orderItemDto.OrderItemId }, orderItemDto);
        }

        // Update OrderItem
        [HttpPut("{orderItemId}")]
        public async Task<ActionResult> UpdateOrderItem(Guid orderItemId, [FromBody] OrderItemDTO orderItemDto)
        {
            await _orderItemService.UpdateOrderItemAsync(orderItemId, orderItemDto);
            return NoContent();
        }

        // Delete OrderItem
        [HttpDelete("{orderItemId}")]
        public async Task<ActionResult> DeleteOrderItem(Guid orderItemId)
        {
            await _orderItemService.DeleteOrderItemAsync(orderItemId);
            return NoContent();
        }
    }
}
