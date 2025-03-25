using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal OriginalPrice { get; set; }
        public int ModelYear { get; set; }
        public string RepairHistory { get; set; }
        public string Condition { get; set; }
        public string Status { get; set; }
        public float Evaluate { get; set; }
        public string Images { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
    }
}
