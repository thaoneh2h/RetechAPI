namespace RetechAPI.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; } 
        public string ElectronicEquipmentType { get; set; } // Loại thiết bị điện tử
        public string BrandName { get; set; } // Tên thương hiệu
    }
}
