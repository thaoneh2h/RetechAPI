using AutoMapper;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.Repositories;
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
