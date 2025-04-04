using Retech.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class ExchangeRequestDTO
    {
        public Guid ExchangeRequestId { get; set; }
        public Guid UserOfferId { get; set; }
        public Guid UserResponseId { get; set; }
        public Guid RequestedProductId { get; set; }
        public Guid OfferedProductId { get; set; }
        public decimal DealPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ExchangeStatus { get; set; } // enum: Pending, Accepted, Rejected, Complete
    }
}
