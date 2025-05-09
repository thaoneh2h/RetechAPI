﻿using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Notification
    {
        [Key]
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }
        public string NotificationType { get; set; }
        public string Content { get; set; }
        public string NotificationStatus { get; set; } // enum: Read, Unread
        public DateTime SendDate { get; set; } = DateTime.UtcNow;
        // Relationships
        public User User { get; set; }
    }
}
