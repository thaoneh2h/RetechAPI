using Retech.Core.Models.Enums;
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
        public FormStatus FormStatus { get; set; } // enum: Pending, Verified, Rejected
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public Product Product { get; set; }
        public User User { get; set; }


    }
}
