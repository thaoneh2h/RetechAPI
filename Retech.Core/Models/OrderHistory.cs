using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class OrderHistory
    {
        [Key]
        public Guid HistoryId { get; set; }
        public Guid OrderId { get; set; }
        public Guid WalletId { get; set; }
        public Guid? VoucherId { get; set; }
        public string TransactionType { get; set; } //enum('Buy','Sell', 'Exchange')
        public string Detail { get; set; }
        public float Amount { get; set; }
        public decimal AmountDecimal { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public Voucher Voucher { get; set; }
        public ICollection<Review> Review { get; set; } = new List<Review>();
        public Order Order { get; set; }
        public E_Wallet EWallet { get; set; }

    }
}
