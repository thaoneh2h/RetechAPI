using AutoMapper;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.Core.Models.Enums;
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
        private readonly IProductRepository _productRepository;
        private readonly IVoucherRepository _voucherRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IVoucherRepository voucherRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _voucherRepository = voucherRepository;
            _mapper = mapper;
        }

        // Propose a new order and calculate TotalPrice from Quantity and UnitPrice
        public async Task ProposeOrderAsync(OrderDTO orderDto)
        {
            var product = await _productRepository.GetByIdAsync(orderDto.ProductId);
            if (product == null || product.ProductType != ProductType.Selling)
                throw new InvalidOperationException("Product is not available for order. Only 'Selling' products can be ordered.");

            var order = _mapper.Map<Order>(orderDto);
            order.UnitPrice = product.SellingPrice;
            order.TotalPrice = order.Quantity * order.UnitPrice;
            // Kiểm tra voucher nếu có
            if (orderDto.VoucherId.HasValue)
            {
                var voucher = await _voucherRepository.GetByIdAsync(orderDto.VoucherId.Value);
                if (voucher == null)
                    throw new InvalidOperationException("Voucher not found.");

                if (voucher.ValidTo < DateTime.UtcNow)
                    throw new InvalidOperationException("Voucher is expired.");

                // Tính toán total price sau khi giảm giá voucher
                decimal discountValue = voucher.DiscountValue;
                if (order.TotalPrice < discountValue)
                    order.TotalPrice = 0;  // Nếu DiscountValue lớn hơn TotalPrice, set TotalPrice = 0
                else
                    order.TotalPrice -= discountValue;

                // Đặt trạng thái voucher là Expired sau khi sử dụng
                voucher.VoucherStatus = VoucherStatus.Expired;
                await _voucherRepository.UpdateAsync(voucher);
            }

            order.OrderStatus = OrderStatus.Pending;  // Đặt trạng thái đơn hàng là Pending
            await _orderRepository.AddAsync(order);
        }

        // Approve the order and calculate TotalPrice from Quantity and UnitPrice
        public async Task ApproveOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found");

            if (order.OrderStatus != OrderStatus.Pending)
                throw new InvalidOperationException("Only orders with 'Pending' status can be approved.");

            var product = await _productRepository.GetByIdAsync(order.ProductId);
            if (product == null || product.ProductType != ProductType.Selling)
                throw new InvalidOperationException("Only products with 'Selling' status can be ordered.");

            order.TotalPrice = order.Quantity * order.UnitPrice;
            order.OrderStatus = OrderStatus.Approved;

            await _orderRepository.UpdateAsync(order);
        }

        // Cancel the order and calculate TotalPrice from Quantity and UnitPrice
        public async Task CancelOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found");

            if (order.OrderStatus != OrderStatus.Pending && order.OrderStatus != OrderStatus.Approved)
                throw new InvalidOperationException("Only orders with 'Approved' and 'Pending' status can be canceled.");

            var product = await _productRepository.GetByIdAsync(order.ProductId);
            if (product == null || product.ProductType != ProductType.Selling)
                throw new InvalidOperationException("Only products with 'Selling' status can be ordered.");

            order.TotalPrice = order.Quantity * order.UnitPrice;
            order.OrderStatus = OrderStatus.Canceled;

            await _orderRepository.UpdateAsync(order);
        }

        // Complete the order and calculate TotalPrice from Quantity and UnitPrice
        public async Task CompleteOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found");

            if (order.OrderStatus != OrderStatus.Approved)
                throw new InvalidOperationException("Only orders with 'Approved' status can be completed.");

            var product = await _productRepository.GetByIdAsync(order.ProductId);
            if (product == null || product.ProductType != ProductType.Selling)
                throw new InvalidOperationException("Only products with 'Selling' status can be ordered.");

            order.TotalPrice = order.Quantity * order.UnitPrice;
            order.OrderStatus = OrderStatus.Completed;

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
