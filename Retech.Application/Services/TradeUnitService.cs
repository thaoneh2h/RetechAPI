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
        private readonly IVoucherRepository _voucherRepo;
        private readonly IMapper _mapper;

        public TradeUnitService(
            IOrderRepository orderRepo,
            IProductRepository productRepo,
            ITransactionRepository transactionRepo,
            IVoucherRepository voucherRepo,
            IMapper mapper)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _transactionRepo = transactionRepo;
            _voucherRepo = voucherRepo;
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
            // Kiểm tra voucher nếu có
            if (orderDto.VoucherId.HasValue)
            {
                var voucher = await _voucherRepo.GetByIdAsync(orderDto.VoucherId.Value);
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
                await _voucherRepo.UpdateAsync(voucher);
            }

            order.OrderStatus = OrderStatus.Pending;  // Đặt trạng thái đơn hàng là Pending
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
            // Cập nhật trạng thái của transaction thành Canceled
            transaction.TransactionStatus = TransactionStatus.Canceled;
            await _transactionRepo.UpdateAsync(transaction);
            // Cập nhật trạng thái của đơn hàng thành Canceled
            order.OrderStatus = OrderStatus.Canceled;
            await _orderRepo.UpdateAsync(order);
            // Nếu voucher có, khôi phục trạng thái voucher thành Active
            if (order.VoucherId.HasValue)
            {
                var voucher = await _voucherRepo.GetByIdAsync(order.VoucherId.Value);
                if (voucher != null)
                {
                    voucher.VoucherStatus = VoucherStatus.Active;  // Khôi phục lại voucher thành Active
                    await _voucherRepo.UpdateAsync(voucher);
                }
            }



        }
    }
}
