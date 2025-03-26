using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.Models
{
    public class Bank
    {
        public Guid BankId { get; set; }  // Primary Key
        public Guid UserId { get; set; }  // Foreign Key referencing User
        public Guid BankName { get; set; }  // Assuming it links to some Bank entity, change if needed
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // Relationship

        public User User { get; set; }  
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();
    }
}
