using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class TransactionDTO
    {
        public Guid TransactionId { get; set; }
        public Guid Participant1Id { get; set; }
        public Guid Participant2Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid? ExchangeRequestId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; } // Buy, Sell, Exchange
        public string TransactionStatus { get; set; } // Pending, Processing, Completed, Canceled
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
