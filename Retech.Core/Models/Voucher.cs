using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Voucher
    {
        [Key]
        public Guid VoucherId { get; set; }
        public Guid UserId { get; set; } // Người sở hữu voucher
        public string VoucherCode { get; set; }
        public decimal DiscountValue { get; set; } // Giá trị giảm giá
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string VoucherStatus { get; set; } // Enum: Active, Expired
        // Relationships
        public User User { get; set; }
        public Order Order { get; set; }
    }
}
