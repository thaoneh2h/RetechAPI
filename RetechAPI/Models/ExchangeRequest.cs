namespace RetechAPI.Models
{
    public class ExchangeRequest
    {
        public Guid ExchangeRequestId { get; set; } 
        public Guid UserOfferId { get; set; } 
        public Guid RequestedProductId { get; set; }
        public Guid OfferedProductId { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; 
        public string ExchangeStatus { get; set; } // enum: Pending, Accepted, Rejected, Complete
    }
}
