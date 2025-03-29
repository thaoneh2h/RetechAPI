using Retech.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class DeviceVerificationFormDTO
    {
        public Guid VerificationSubmitId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public DateTime VerificationDate { get; set; }
        public string Location { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FormStatus FormStatus { get; set; }


    }

}
