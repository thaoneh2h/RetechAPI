using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Review
    {
        [Key]
        public Guid ReviewId { get; set; }
        public Guid ReviewerId { get; set; }
        public Guid RevieweeId { get; set; }
        public Guid OrderId { get; set; }
        public string Comment { get; set; }
        public float Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public User Reviewer { get; set; }
        public User Reviewee { get; set; }
        
        public Order Order { get; set; }
    }
}
