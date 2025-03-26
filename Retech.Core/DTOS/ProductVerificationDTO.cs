using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class ProductVerificationDTO
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string VerificationStatus { get; set; } // Pending, In Progress, Completed
        public float VerificationResult { get; set; }
        public decimal SuggestPrice { get; set; }
    }

}
