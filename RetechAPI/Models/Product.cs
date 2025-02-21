namespace RetechAPI.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; } // Chủ sở hữu sản phẩm
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Condition { get; set; } // Enum: New, Like New, Used
        public string Status { get; set; } // Enum: Available, Out of Stock
        public float Evaluate { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public int CategoryId { get; set; } // FK
        public string Images { get; set; } // JSON lưu danh sách ảnh
        public int Stock { get; set; }
    }
}
