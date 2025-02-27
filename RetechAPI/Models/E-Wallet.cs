using System.ComponentModel.DataAnnotations;

namespace RetechAPI.Models
{
    public class E_Wallet
    {
        [Key]
        public Guid WalletId { get; set; } 
        public Guid UserId { get; set; } 
        public string Type { get; set; } // Loại ví (ví dụ: "Personal", "Business")
        public decimal Balance { get; set; } 
        public string Currency { get; set; } = "VND"; 
        public string Status { get; set; } // enum: Active, Suspended, Closed
        public bool KycVerified { get; set; } = false; // Xác minh KYC, mặc định false
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public User User { get; set; }
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();
        public ICollection<Order> Order { get; set;} = new List<Order>();
        public ICollection<TransactionHistory> TransactionHistory { get; set; } = new List<TransactionHistory>();

    }
}
