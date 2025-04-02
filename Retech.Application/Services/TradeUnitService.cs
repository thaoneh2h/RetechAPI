using AutoMapper;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.Core.Models.Enums;
using Retech.DataAccess.Repositories.Interfaces;

namespace Retech.Application.Services
{
    public class TradeUnitService : ITradeUnitService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
        private readonly ITransactionRepository _transactionRepo;
        private readonly IMapper _mapper;

        public TradeUnitService(
            IOrderRepository orderRepo,
            IProductRepository productRepo,
            ITransactionRepository transactionRepo,
            IMapper mapper)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _transactionRepo = transactionRepo;
            _mapper = mapper;
        }

        public async Task ProposeOrderAsync(OrderDTO orderDto)
        {
            var product = await _productRepo.GetByIdAsync(orderDto.ProductId);
            if (product == null || product.ProductType != ProductType.Selling)
                throw new InvalidOperationException("Product is not available for order. Only 'Selling' products can be ordered.");

            var order = _mapper.Map<Order>(orderDto);
            order.UnitPrice = product.SellingPrice;
            order.TotalPrice = order.Quantity * order.UnitPrice;
            order.OrderStatus = OrderStatus.Pending;

            await _orderRepo.AddAsync(order);
        }

        public async Task ApproveOrderAndCreateTransactionAsync(Guid orderId)
        {
            var order = await _orderRepo.GetByIdAsync(orderId)
                ?? throw new Exception("Order not found.");

            if (order.OrderStatus != OrderStatus.Pending)
                throw new InvalidOperationException("Only orders with 'Pending' status can be approved.");

            var product = await _productRepo.GetByIdAsync(order.ProductId);
            if (product == null || product.ProductType != ProductType.Selling)
                throw new InvalidOperationException("Product is not valid for selling.");

            if (product.Stock < order.Quantity)
                throw new InvalidOperationException("Not enough stock to fulfill the order.");

            product.Stock -= order.Quantity;
            await _productRepo.UpdateAsync(product);

            order.OrderStatus = OrderStatus.Approved;
            order.TotalPrice = order.Quantity * order.UnitPrice;
            await _orderRepo.UpdateAsync(order);

            var transaction = new Transaction
            {
                OrderId = order.OrderId,
                Participant1Id = order.BuyerId,
                Participant2Id = order.SellerId,
                TransactionType = TransactionType.Sell,
                Quantity = order.Quantity,
                Price = order.TotalPrice,
                TransactionStatus = TransactionStatus.Processing,
                CreatedAt = DateTime.UtcNow
            };

            await _transactionRepo.AddAsync(transaction);
        }

        public async Task CompleteTransactionAsync(Guid transactionId)
        {
            var transaction = await _transactionRepo.GetByIdAsync(transactionId)
                ?? throw new Exception("Transaction not found.");

            var order = transaction.Order
                ?? throw new Exception("Linked order not found.");

            if (transaction.TransactionStatus != TransactionStatus.Processing)
                throw new InvalidOperationException("Transaction must be in 'Processing' status to complete.");

            transaction.TransactionStatus = TransactionStatus.Completed;
            await _transactionRepo.UpdateAsync(transaction);

            order.OrderStatus = OrderStatus.Completed;
            await _orderRepo.UpdateAsync(order);
        }

        public async Task CancelTransactionAsync(Guid transactionId)
        {
            var transaction = await _transactionRepo.GetByIdAsync(transactionId)
                ?? throw new Exception("Transaction not found.");

            var order = transaction.Order
                ?? throw new Exception("Linked order not found.");

            if (transaction.TransactionStatus != TransactionStatus.Processing)
                throw new InvalidOperationException("Transaction must be in 'Processing' status to cancel.");

            var product = await _productRepo.GetByIdAsync(order.ProductId);
            if (product != null)
            {
                product.Stock += order.Quantity;
                await _productRepo.UpdateAsync(product);
            }

            transaction.TransactionStatus = TransactionStatus.Canceled;
            await _transactionRepo.UpdateAsync(transaction);

            order.OrderStatus = OrderStatus.Canceled;
            await _orderRepo.UpdateAsync(order);
        }
    }
}
