using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? WalletId { get; set; }
        public Guid? ExchangeRequestId { get; set; }
        public Guid? SubscriptionId { get; set; }
        public decimal FeePercentage { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // Enum: Bank Transfer, E-Wallet, Credit Card, Cash, Other
        public string PaymentType { get; set; } // Enum: Deposit, Withdrawal
        public string TransactionStatus { get; set; } // Enum: Pending, Completed, Failed, Cancelled
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public Order Order { get; set; }
        public ExchangeRequest ExchangeRequest { get; set; }
        public UserSubscription UserSubscription { get; set; }
        public E_Wallet EWallet { get; set; }
    }
}
