using Retech.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.Models
{
    public class Transaction
    {
        [Key]
        public Guid TransactionId { get; set; }
        [Required]
        public Guid Participant1Id { get; set; }
        [Required]
        public Guid Participant2Id { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ExchangeRequestId { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [EnumDataType(typeof(TransactionType))]
        public TransactionType TransactionType { get; set; } // Sell, Exchange
        [EnumDataType(typeof(TransactionStatus))]
        public TransactionStatus TransactionStatus { get; set; } // Processing, Completed, Canceled
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relationships
        public User Participant1 { get; set; }
        public User Participant2 { get; set; }
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();
        public Order Order { get; set; }
        public ExchangeRequest ExchangeRequest { get; set; }


    }

}
