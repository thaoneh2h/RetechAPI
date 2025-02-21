namespace RetechAPI.Models
{
    public class Notification
    {
        public Guid NotificationId { get; set; } 
        public Guid UserId { get; set; } 
        public string Type { get; set; } 
        public string Content { get; set; } 
        public string Status { get; set; } // enum: Read, Unread
        public DateTime SendDate { get; set; } = DateTime.UtcNow; 
    }
}
