using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class CategoryDTO
    {
        public Guid CategoryId { get; set; }

        [Required]  // Đảm bảo không có trường nào trống
        [StringLength(100)]  // Giới hạn độ dài tên loại thiết bị
        public string ElectronicEquipmentType { get; set; }

        [StringLength(100)]  // Giới hạn độ dài tên thương hiệu
        public string BrandName { get; set; }
    }
}
