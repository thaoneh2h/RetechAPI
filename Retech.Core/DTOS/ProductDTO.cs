using Retech.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProductType ProductType { get; set; } //Enum: Selling, Exchanging
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Condition Condition { get; set; } // Enum: New, Like New, Used
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProductStatus ProductStatus { get; set; } // Enum: Verified, Not Verified
        public float Evaluate { get; set; }
        public string Images { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
        public string BrandName { get; set; }
    }
}
