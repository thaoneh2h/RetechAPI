using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;

namespace Retech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("propose")]
        public async Task<ActionResult> ProposeOrder([FromBody] OrderDTO orderDto)
        {
            try
            {
                await _orderService.ProposeOrderAsync(orderDto);  // Logic for when a buyer proposes an order
                return CreatedAtAction(nameof(GetOrderById), new { orderId = orderDto.OrderId }, orderDto);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("approve/{orderId}")]
        public async Task<ActionResult> ApproveOrder(Guid orderId)
        {
            try
            {
                await _orderService.ApproveOrderAsync(orderId);  // Logic for when a seller confirms the order
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while approving the order: " + ex.Message });
            }
        }

        [HttpPut("cancel/{orderId}")]
        public async Task<ActionResult> CancelOrder(Guid orderId)
        {
            try
            {
                await _orderService.CancelOrderAsync(orderId);  // Logic for canceling the order
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while canceling the order: " + ex.Message });
            }
        }

        [HttpPut("complete/{orderId}")]
        public async Task<ActionResult> CompleteOrder(Guid orderId)
        {
            try
            {
                await _orderService.CompleteOrderAsync(orderId);  // Logic for completing the transaction (could also mark as shipped, etc.)
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while completing the order: " + ex.Message });
            }
        }



        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDTO>> GetOrderById(Guid orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] OrderDTO orderDto)
        {
            await _orderService.CreateOrderAsync(orderDto);
            return CreatedAtAction(nameof(GetOrderById), new { orderId = orderDto.OrderId }, orderDto);
        }

        [HttpPut("{orderId}")]
        public async Task<ActionResult> UpdateOrder(Guid orderId, [FromBody] OrderDTO orderDto)
        {
            await _orderService.UpdateOrderAsync(orderId, orderDto);
            return NoContent();
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrder(Guid orderId)
        {
            await _orderService.DeleteOrderAsync(orderId);
            return NoContent();
        }
    }
}
