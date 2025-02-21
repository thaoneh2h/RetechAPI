namespace RetechAPI.Models
{
    public class E_Wallet
    {
        public Guid WalletId { get; set; } 
        public Guid UserId { get; set; } 
        public string Type { get; set; } // Loại ví (ví dụ: "Personal", "Business")
        public decimal Balance { get; set; } 
        public string Currency { get; set; } = "VND"; 
        public string Status { get; set; } // enum: Active, Suspended, Closed
        public bool KycVerified { get; set; } = false; // Xác minh KYC, mặc định false
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    }
}
