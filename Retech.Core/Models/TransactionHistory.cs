using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class TransactionHistory
    {
        [Key]
        public Guid TransactionId { get; set; }
        public Guid OrderId { get; set; }
        public Guid WalletId { get; set; }
        public Guid? VoucherId { get; set; }
        public Guid? ReviewId { get; set; }
        public string TransactionType { get; set; } //enum('Buy','Sell', 'Exchange')
        public string Detail { get; set; }
        public string Type { get; set; }
        public float Amount { get; set; }
        public decimal AmountDecimal { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public Voucher Voucher { get; set; }
        public Review Review { get; set; }
        public Order Order { get; set; }
        public E_Wallet EWallet { get; set; }

    }
}
