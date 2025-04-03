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
    public class VoucherDTO
    {
        public Guid VoucherId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string VoucherCode { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Discount value must be greater than 0.")]
        public decimal DiscountValue { get; set; }
        public DateTime ValidTo { get; set; }

    }
}
