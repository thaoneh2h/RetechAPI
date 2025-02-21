namespace RetechAPI.Models
{
    public class ThirdPartyProvider
    {
        public Guid ProviderId { get; set; } 
        public string ProviderName { get; set; } 
        public string ServiceType { get; set; } // enum: Device Verification, Shipping
        public string ContactInfo { get; set; } 
        public string Status { get; set; } // enum : Active, Inactive
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    }
}
