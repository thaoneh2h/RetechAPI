namespace RetechAPI.Models
{
    public class Message
    {
        public Guid MessageId { get; set; } 
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; } 
        public string Content { get; set; } 
        public DateTime SendDate { get; set; } = DateTime.UtcNow; 
    }
}
