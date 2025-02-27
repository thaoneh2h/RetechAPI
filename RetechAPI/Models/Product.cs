using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;

namespace RetechAPI.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; } // Chủ sở hữu sản phẩm
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Condition { get; set; } // Enum: New, Like New, Used
        public string Status { get; set; } // Enum: Available, Out of Stock
        public float Evaluate { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public Guid CategoryId { get; set; } // FK
        public string Images { get; set; } // JSON lưu danh sách ảnh
        public int Stock { get; set; }
        // Relationships
        public User User { get; set; }
        public Category Category { get; set; }
        public DeviceVerification DeviceVerification { get; set; }
        public ICollection<ExchangeRequest> RequestedExchange { get; set; } = new List<ExchangeRequest>();  // Sản phẩm được yêu cầu
        public ICollection<ExchangeRequest> OfferedExchange { get; set; } = new List<ExchangeRequest>();  // Sản phẩm đưa ra trao đổi
        public ICollection<OrderItem> OrderItem { get; set; } = new List<OrderItem>();
        public ICollection<ShoppingCart> ShoppingCart { get; } = new List<ShoppingCart>();
    }
}
