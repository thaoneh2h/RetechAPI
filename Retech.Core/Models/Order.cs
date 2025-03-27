using Retech.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid BuyerId { get; set; }  // Reference to the buyer
        public Guid SellerId { get; set; } // Reference to the seller
        public Guid WalletId { get; set; }
        public Guid? VoucherId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; } //enum : Pending, Approved, Delivered, Canceled
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus OrderStatusEnum { get; set; }

        // Relationships
        public User Buyer { get; set; }
        public User Seller { get; set; }
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();
        public Voucher Voucher { get; set; }
        public E_Wallet EWallet { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; } = new List<OrderItem>();
        public Shipping Shipping { get; set; }
        public ICollection<Transaction> Transaction { get; set; } = new List<Transaction>();
        public ICollection<Review> Review { get; set; } = new List<Review>();
    }

}
