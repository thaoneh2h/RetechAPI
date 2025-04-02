using Retech.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public Guid UserId { get; set; } // Chủ sở hữu sản phẩm
        [Required]
        public Guid CategoryId { get; set; } 
        [Required]
        [StringLength(200)]  // Đảm bảo tên sản phẩm không quá 200 ký tự
        public string ProductName { get; set; }
        [StringLength(1000)]  // Đảm bảo mô tả sản phẩm không quá 1000 ký tự
        public string Description { get; set; }
        [Range(0, double.MaxValue)]  // Đảm bảo giá bán là số không âm
        public decimal SellingPrice { get; set; }
        [Range(0, double.MaxValue)]
        public decimal OriginalPrice { get; set; }
        [Range(1900, int.MaxValue)]  // Đảm bảo năm mẫu mã hợp lệ
        public int ModelYear { get; set; }
        public string RepairHistory { get; set; }
        [EnumDataType(typeof(ProductType))]  // Enum: Selling, Exchanging
        public ProductType ProductType { get; set; } //Enum: Selling, Exchanging
        [EnumDataType(typeof(Condition))]  // Enum: New, Like New, Used
        public Condition Condition { get; set; } // Enum: New, Like New, Used
        [EnumDataType(typeof(ProductStatus))]  // Enum: Verified, Not Verified
        public ProductStatus ProductStatus { get; set; } = ProductStatus.NotVerified; // Enum: Verified, Not Verified
        [Range(0, 5)]  // Đảm bảo đánh giá trong khoảng từ 0 đến 5
        public float Evaluate { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string Images { get; set; } // JSON lưu danh sách ảnh
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
        


        // Relationships
        public User User { get; set; }
        public Category Category { get; set; }
        public ICollection<DeviceVerificationForm> DeviceVerificationForm { get; set; } = new List<DeviceVerificationForm>();
        public ICollection<ExchangeRequest> RequestedExchange { get; set; } = new List<ExchangeRequest>();  // Sản phẩm được yêu cầu
        public ICollection<ExchangeRequest> OfferedExchange { get; set; } = new List<ExchangeRequest>();  // Sản phẩm đưa ra trao đổi
        public ICollection<Order> Order { get; set; } = new List<Order>();
        public ICollection<ShoppingCart> ShoppingCart { get; } = new List<ShoppingCart>();
        public ICollection<ProductVerification> ProductVerification { get; set; } = new List<ProductVerification>();
       
      
    }
}
