using System.ComponentModel.DataAnnotations;

namespace RetechAPI.Models
{
    public class ShoppingCart
    {
        [Key]
        public Guid CartId { get; set; } 
        public Guid UserId { get; set; } // Người sở hữu giỏ hàng
        public Guid ProductId { get; set; } // Sản phẩm trong giỏ hàng
        public int Quantity { get; set; }
        // Relationships
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
