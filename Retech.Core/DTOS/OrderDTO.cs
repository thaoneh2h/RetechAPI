using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        public Guid BuyerId { get; set; } 
        public Guid SellerId { get; set; }
        public Guid WalletId { get; set; }
        public Guid? VoucherId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
