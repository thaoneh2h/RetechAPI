﻿using Retech.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Voucher
    {
        [Key]
        public Guid VoucherId { get; set; }
        [Required]
        public Guid UserId { get; set; } // Người sở hữu voucher
        [Required]
        [StringLength(50)]
        public string VoucherCode { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Discount value must be greater than 0.")]
        public decimal DiscountValue { get; set; } // Giá trị giảm giá
        public DateTime ValidTo { get; set; }
        [EnumDataType(typeof(VoucherStatus))]
        public VoucherStatus VoucherStatus { get; set; } // Enum: Active, Expired
        // Relationships
        public User User { get; set; }
        public Order Order { get; set; }
    }
}
