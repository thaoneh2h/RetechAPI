using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class UpdateExchangeRequestDTO
    {
        public Guid ExchangeRequestId { get; set; }
        public decimal DealPrice { get; set; }
    }
}
