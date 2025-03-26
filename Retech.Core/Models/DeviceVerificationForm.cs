using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class DeviceVerificationForm
    {
        [Key]
        public Guid VerificationSubmitId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public DateTime VerificationDate {  get; set; } 
        public string FormStatus { get; set; } // enum: Pending, In Progress, Completed, Failed
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public Product Product { get; set; }
        public User User { get; set; }


    }
}
