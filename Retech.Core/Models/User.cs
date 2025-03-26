using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string UserRole { get; set; }  // Enum: Buyer, Seller, Exchange Staff, Admin
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }  // Enum: Male, Female, Other
        public DateTime BirthDate { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }  // Enum: Active, Suspended
        public float Rating { get; set; }
        public bool KycVerified { get; set; } = false;

        // Relationships
        public ICollection<Voucher> Voucher { get; set; } = new List<Voucher>();
        public ICollection<OrderHistory> TransactionHistory { get; set; } = new List<OrderHistory>();
        public ICollection<Order> BuyerId { get; set; } = new List<Order>();
        public ICollection<Order> SellerId { get; set; } = new List<Order>();
        public E_Wallet EWallet { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public ICollection<Product> Product { get; set; } = new List<Product>();
        public ICollection<ExchangeRequest> UserOfferId { get; set; } = new List<ExchangeRequest>();
        public ICollection<ExchangeRequest> UserResponseId { get; set; } = new List<ExchangeRequest>();
        public ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
        public ICollection<Notification> Notification { get; set; } = new List<Notification>();
        public ICollection<DeviceVerificationForm> DeviceVerificationForm { get; set; } = new List<DeviceVerificationForm>();
        public ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
        public ICollection<Review> ReviewerReview { get; set; } = new List<Review>();
        public ICollection<Review> RevieweeReview { get; set; } = new List<Review>();
        public ICollection<ProductVerification> ProductVerification { get; set; } = new List<ProductVerification>();
        public UserSubscription UserSubscription { get; set; }
        public ICollection<Transaction> ParticipantId1 { get; set; } = new List<Transaction>();
        public ICollection<Transaction> ParticipantId2 { get; set; } = new List<Transaction>();
        public ICollection<Bank> Bank { get; set; }= new List<Bank>();
    }
}
