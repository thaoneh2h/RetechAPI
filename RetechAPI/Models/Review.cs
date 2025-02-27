using System.ComponentModel.DataAnnotations;

namespace RetechAPI.Models
{
    public class Review
    {
        [Key]
        public Guid ReviewId { get; set; } 
        public Guid UserId { get; set; } 
        public Guid TransactionId { get; set; } 
        public string Comment { get; set; } 
        public string Rating { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public User User { get; set; }
        public ICollection<TransactionHistory> TransactionHistory { get; set; } = new List<TransactionHistory>();
    }
}
