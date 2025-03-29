﻿using Retech.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; } // Chủ sở hữu sản phẩm
        public Guid CategoryId { get; set; } // FK
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal OriginalPrice { get; set; }
        public int ModelYear { get; set; }
        public string RepairHistory { get; set; }
        public ProductType ProductType { get; set; } //Enum: Selling, Exchanging
        public Condition Condition { get; set; } // Enum: New, Like New, Used
        public ProductStatus ProductStatus { get; set; } // Enum: Verified, Not Verified
        public float Evaluate { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string Images { get; set; } // JSON lưu danh sách ảnh
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
