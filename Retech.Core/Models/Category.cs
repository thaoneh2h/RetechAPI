using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string ElectronicEquipmentType { get; set; } // Loại thiết bị điện tử
        public string BrandName { get; set; } // Tên thương hiệu
        // Relationships
        public ICollection<Product> Product { get; set; } = new List<Product>();
    }
}
