using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public Guid WalletId { get; set; }
        public Guid? VoucherId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; } //enum : Placed, Approved, Delivered, Canceled
        public string OrderCondition { get; set; } // enum : Processing, Shipping, Delivered
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public User User { get; set; }
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();
        public Voucher Voucher { get; set; }
        public E_Wallet EWallet { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; } = new List<OrderItem>();
        public Shipping Shipping { get; set; }
        public ICollection<OrderHistory> OrderHistory { get; set; } = new List<OrderHistory>();
    }
}
