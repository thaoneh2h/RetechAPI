using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.Models
{
    public class ProductVerification
    {
        [Key]
        public Guid ProductVerificationId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string VerificationStatus { get; set; } //enum: completed, Rejected
        public float VerificationResult { get; set; }
        public decimal SuggestPrice { get; set; }
        public DateTime CreateAt { get; set; }
        //relationships
        public User User { get; set; }
        public Product Product { get; set; }
        
    }
}
