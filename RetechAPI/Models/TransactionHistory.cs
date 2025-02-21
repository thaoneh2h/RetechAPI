namespace RetechAPI.Models
{
    public class TransactionHistory
    {
        public Guid TransactionId { get; set; } 
        public Guid OrderId { get; set; } 
        public Guid WalletId { get; set; } 
        public Guid VoucherId { get; set; } 
        public string Detail { get; set; } 
        public string Type { get; set; } 
        public float Amount { get; set; } 
        public decimal AmountDecimal { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    }
}
