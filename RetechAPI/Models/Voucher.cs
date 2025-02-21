namespace RetechAPI.Models
{
    public class Voucher
    {
        public Guid VoucherId { get; set; }
        public Guid UserId { get; set; } // Người sở hữu voucher
        public decimal DiscountValue { get; set; } // Giá trị giảm giá
        public decimal MaxDiscountValue { get; set; } // Mức giảm tối đa
        public DateTime ValidFrom { get; set; } 
        public DateTime ValidTo { get; set; } 
        public string Status { get; set; } // Enum: Active, Expired
    }
}
