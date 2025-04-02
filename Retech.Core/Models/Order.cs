using Retech.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        [Required]
        public Guid BuyerId { get; set; }  // Reference to the buyer
        [Required]
        public Guid SellerId { get; set; } // Reference to the seller
        [Required]
        public Guid WalletId { get; set; }
        public Guid? VoucherId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than 0.")]
        public decimal UnitPrice { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Total price must be greater than 0.")]
        public decimal TotalPrice { get; set; }
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus OrderStatus { get; set; } //enum : Pending, Approved, Delivered, Canceled
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        


        // Relationships
        public User Buyer { get; set; }
        public User Seller { get; set; }
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();
        public Voucher Voucher { get; set; }
        public E_Wallet EWallet { get; set; }

        public Shipping Shipping { get; set; }
        public ICollection<Transaction> Transaction { get; set; } = new List<Transaction>();
        public ICollection<Review> Review { get; set; } = new List<Review>();
        public Product Product { get; set; }

    }

}
