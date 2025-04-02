using Retech.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class DeviceVerificationForm
    {
        [Key]
        public Guid VerificationSubmitId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public DateTime VerificationDate {  get; set; }
        [EnumDataType(typeof(FormStatus))]
        public FormStatus FormStatus { get; set; } // enum: Pending, Verified, Rejected
        [Required]  
        [StringLength(255)]
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public Product Product { get; set; }
        public User User { get; set; }


    }
}
