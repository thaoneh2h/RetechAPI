using Retech.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class E_Wallet
    {
        [Key]
        public Guid WalletId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Balance must be greater than 0.")]
        public decimal Balance { get; set; }
        public string Currency { get; set; } = "RetechCoin";
        [EnumDataType(typeof(WalletStatus))]
        public WalletStatus WalletStatus { get; set; } = WalletStatus.Active; // enum: Active, Suspended, Closed
        public bool KycVerified { get; set; } = false; // Xác minh KYC, mặc định false
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public User User { get; set; }
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();
        public ICollection<Order> Order { get; set; } = new List<Order>();

    }
}
