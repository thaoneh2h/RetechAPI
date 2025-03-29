using Retech.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class ProductVerificationDTO
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public VerificationStatus VerificationStatus { get; set; } //enum: completed, Rejected
        public float VerificationResult { get; set; }
        public decimal SuggestPrice { get; set; }
    }

}
