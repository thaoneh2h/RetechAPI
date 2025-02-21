namespace RetechAPI.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public Guid WalletId { get; set; }
        public Guid PaymentId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; } //enum : Placed, Approved, Delivered, Canceled
        public string OrderCondition { get; set; } // enum : Processing, Shipping, Delivered
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
