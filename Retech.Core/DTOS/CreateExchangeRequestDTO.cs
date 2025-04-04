using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class CreateExchangeRequestDTO
    {
        public Guid UserOfferId { get; set; }
        public Guid UserResponseId { get; set; }
        public Guid RequestedProductId { get; set; }
        public Guid OfferedProductId { get; set; }
        public decimal DealPrice { get; set; }
    }
}
