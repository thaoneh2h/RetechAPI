namespace Retech.Core.DTOS
{
    public class CreateReviewDTO
    {
        public Guid UserId { get; set; }
        public Guid TransactionId { get; set; }
        public string Comment { get; set; }
        public string Rating { get; set; }
    }
}
