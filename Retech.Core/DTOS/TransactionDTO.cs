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
    public class TransactionDTO
    {
        public Guid TransactionId { get; set; }
        public Guid Participant1Id { get; set; }
        public Guid Participant2Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid? ExchangeRequestId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(TransactionType))]
        public TransactionType TransactionType { get; set; } // Buy, Sell, Exchange
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(TransactionStatus))]
        public TransactionStatus TransactionStatus { get; set; } // Pending, Completed, Canceled
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
