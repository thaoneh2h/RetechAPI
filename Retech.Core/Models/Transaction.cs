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
        public Guid BuyerId { get; set; }
        public Guid SellerId { get; set; }
        public Guid ProductId { get; set; }
        public Guid? WalletId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; } // Buy, Sell, Exchange
        public string TransactionStatus { get; set; } // Pending, Processing, Completed, Canceled
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relationships
        public User Buyer { get; set; }
        public User Seller { get; set; }
        public Product Product { get; set; }
        public E_Wallet EWallet { get; set; }

    }

}
