﻿using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class ExchangeRequest
    {
        [Key]
        public Guid ExchangeRequestId { get; set; }
        public Guid UserOfferId { get; set; }
        public Guid UserResponseId { get; set; }
        public Guid RequestedProductId { get; set; }
        public Guid OfferedProductId { get; set; }
        public decimal DealPrice { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string ExchangeStatus { get; set; } // enum: Pending, Accepted, Rejected, Complete
        // Relationships
        public User UserOffer { get; set; }  // Người gửi yêu cầu trao đổi
        public User UserResponse { get; set; }
        public Product RequestedProduct { get; set; }  // Sản phẩm mà người dùng muốn nhận
        public Product OfferedProduct { get; set; }  // Sản phẩm mà người dùng muốn trao đổi
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();
        public ICollection<Transaction> Transaction  { get; set; } = new List<Transaction>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();

    }
}
