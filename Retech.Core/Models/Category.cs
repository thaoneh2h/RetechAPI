using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required]  // Đảm bảo không có trường nào trống
        [StringLength(100)]  // Giới hạn độ dài tên loại thiết bị
        public string ElectronicEquipmentType { get; set; } // Loại thiết bị điện tử
        [StringLength(100)]  // Giới hạn độ dài tên thương hiệu
        public string BrandName { get; set; } // Tên thương hiệu
        // Relationships
        public ICollection<Product> Product { get; set; } = new List<Product>();
    }
}
