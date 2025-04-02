using Retech.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class RequestProductDTO
    {
        public Guid ProductId { get; set; }
        [Required]  // Đảm bảo UserId không thể trống
        public Guid UserId { get; set; }
        [Required]  // Đảm bảo tên sản phẩm không thể trống
        [StringLength(200)]  // Giới hạn độ dài tên sản phẩm
        public string ProductName { get; set; }
        [StringLength(1000)]  // Giới hạn độ dài mô tả sản phẩm
        public string Description { get; set; }
        [Range(0, double.MaxValue)]  // Đảm bảo giá bán là số không âm
        public decimal SellingPrice { get; set; }
        [Range(0, double.MaxValue)]  // Đảm bảo giá gốc là số không âm
        public decimal OriginalPrice { get; set; }
        [Range(1900, int.MaxValue)]  // Đảm bảo năm mẫu mã hợp lệ
        public int ModelYear { get; set; }
        public string RepairHistory { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(ProductType))]  // Enum: Selling, Exchanging
        public ProductType ProductType { get; set; } //Enum: Selling, Exchanging

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(Condition))]  // Enum: New, Like New, Used
        public Condition Condition { get; set; } // Enum: New, Like New, Used

        [StringLength(5000)]  // Giới hạn độ dài chuỗi URL hình ảnh
        public string Images { get; set; }
        [Range(0, int.MaxValue)]  // Đảm bảo số lượng trong kho là số không âm
        public int Stock { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
    }
}
