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
    public class ProductVerificationDTO
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(VerificationStatus))]
        public VerificationStatus VerificationStatus { get; set; } //enum: completed, Rejected
        [Range(0, 5)]
        public float VerificationResult { get; set; }
        [Range(0, double.MaxValue)]
        public decimal SuggestPrice { get; set; }
    }

}
