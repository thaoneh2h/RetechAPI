using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Message
    {
        [Key]
        public Guid MessageId { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; } = DateTime.UtcNow;
        // Relationships
        public User Sender { get; set; }  // Mối quan hệ với người gửi
        public User Receiver { get; set; }  // Mối quan hệ với người nhận

    }
}
