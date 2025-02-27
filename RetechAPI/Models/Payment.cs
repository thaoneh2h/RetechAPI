﻿using System.ComponentModel.DataAnnotations;

namespace RetechAPI.Models
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }
        public Guid OrderId { get; set; }
        public Guid WalletId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // Enum: Bank Transfer, E-Wallet, Credit Card, Cash, Other
        public string PaymentType { get; set; } // Enum: Deposit, Withdrawal
        public string TransactionStatus { get; set; } // Enum: Pending, Completed, Failed, Cancelled
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Relationships
        public Order Order { get; set; }
        public E_Wallet EWallet { get; set; }
    }
}
