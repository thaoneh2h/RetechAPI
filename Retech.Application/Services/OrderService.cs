using AutoMapper;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services
{
    public class OrderService : IOrderService
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;

            public OrderService(IOrderRepository orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }
        public async Task ProposeOrderAsync(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.OrderStatus = "Pending";  // Initially, when buyer proposes an order
            await _orderRepository.AddAsync(order);
        }

        public async Task ApproveOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found");

            order.OrderStatus = "Approved";  // Seller approves the order
            await _orderRepository.UpdateAsync(order);
        }

        public async Task CancelOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found");

            order.OrderStatus = "Cancelled";  // Cancel the order
            await _orderRepository.UpdateAsync(order);
        }

        public async Task CompleteOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found");

            order.OrderStatus = "Completed";  // Complete the order
            await _orderRepository.UpdateAsync(order);
        }

        public async Task<OrderDTO> GetOrderByIdAsync(Guid orderId)
            {
                var order = await _orderRepository.GetByIdAsync(orderId);
                return _mapper.Map<OrderDTO>(order);
            }

            public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
            {
                var orders = await _orderRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<OrderDTO>>(orders);
            }

            public async Task CreateOrderAsync(OrderDTO orderDto)
            {
                var order = _mapper.Map<Order>(orderDto);
                await _orderRepository.AddAsync(order);
            }

            public async Task UpdateOrderAsync(Guid orderId, OrderDTO orderDto)
            {
                var order = _mapper.Map<Order>(orderDto);
                order.OrderId = orderId;  // Ensuring that the correct order is updated
                await _orderRepository.UpdateAsync(order);
            }

            public async Task DeleteOrderAsync(Guid orderId)
            {
                await _orderRepository.DeleteAsync(orderId);
            }
        }
    }
