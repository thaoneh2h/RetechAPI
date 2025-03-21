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
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<OrderItemDTO> GetOrderItemByIdAsync(Guid orderItemId)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(orderItemId);
            return _mapper.Map<OrderItemDTO>(orderItem);
        }

        public async Task<IEnumerable<OrderItemDTO>> GetOrderItemsByOrderIdAsync(Guid orderId)
        {
            var orderItems = await _orderItemRepository.GetByOrderIdAsync(orderId);
            return _mapper.Map<IEnumerable<OrderItemDTO>>(orderItems);
        }

        public async Task CreateOrderItemAsync(OrderItemDTO orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            await _orderItemRepository.AddAsync(orderItem);
        }

        public async Task UpdateOrderItemAsync(Guid orderItemId, OrderItemDTO orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            orderItem.OrderItemId = orderItemId;  // Ensuring the correct item is updated
            await _orderItemRepository.UpdateAsync(orderItem);
        }

        public async Task DeleteOrderItemAsync(Guid orderItemId)
        {
            await _orderItemRepository.DeleteAsync(orderItemId);
        }
    }
}

