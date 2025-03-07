using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
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
        public TransactionHistory TransactionHistory { get; set; }
    }
}
