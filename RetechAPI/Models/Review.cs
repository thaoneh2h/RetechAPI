namespace RetechAPI.Models
{
    public class Review
    {
        public Guid ReviewId { get; set; } 
        public Guid UserId { get; set; } 
        public Guid TransactionId { get; set; } 
        public string Comment { get; set; } 
        public string Rating { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    }
}
