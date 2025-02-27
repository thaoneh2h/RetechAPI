using System.ComponentModel.DataAnnotations;

namespace RetechAPI.Models
{
    public class OrderItem
    {
        [Key]
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        // Relationships
        public Order Order { get; set; }
        public Product Product { get; set; }
    }

}
