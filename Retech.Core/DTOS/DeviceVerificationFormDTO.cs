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
    public class DeviceVerificationFormDTO
    {
        public Guid VerificationSubmitId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format. Please use yyyy-MM-dd.")]
        public DateTime VerificationDate { get; set; }
        [Required]
        public string Location { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(FormStatus))]
        public FormStatus FormStatus { get; set; }


    }

}
