namespace RetechAPI.Models
{
    public class ShoppingCart
    {
        public Guid CartId { get; set; } 
        public Guid UserId { get; set; } // Người sở hữu giỏ hàng
        public Guid ProductId { get; set; } // Sản phẩm trong giỏ hàng
        public int Quantity { get; set; } 
    }
}
