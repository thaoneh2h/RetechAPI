using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class DeviceVerification
    {
        [Key]
        public Guid VerificationId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public Guid? ThirdPartyProviderId { get; set; }
        public string Status { get; set; } // enum: Pending, In Progress, Completed, Failed
        public string VerificationResult { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public Product Product { get; set; }
        public ThirdPartyProvider ThirdPartyProvider { get; set; }
        public User User { get; set; }


    }
}
