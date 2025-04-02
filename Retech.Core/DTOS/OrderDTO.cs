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
    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        [Required]
        public Guid BuyerId { get; set; }
        [Required]
        public Guid SellerId { get; set; }
        [Required]
        public Guid WalletId { get; set; }
        public Guid? VoucherId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
