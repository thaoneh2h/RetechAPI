using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class ThirdPartyProvider
    {
        [Key]
        public Guid ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ContactInfo { get; set; }
        public string ProviderStatus { get; set; } // enum : Active, Inactive
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public ICollection<Shipping> shippings { get; set; } = new List<Shipping>();

    }
}
