namespace Retech.Core.DTOS
{
    public class ReviewDTO
    {
        public Guid ReviewId { get; set; }
        public string UserName { get; set; }  // From User model
        public string Comment { get; set; }
        public string Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
