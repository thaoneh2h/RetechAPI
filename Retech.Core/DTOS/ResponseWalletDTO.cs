using Retech.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class ResponseWalletDTO
    {
        public Guid WalletId { get; set; }

        public Guid UserId { get; set; }

        public decimal Balance { get; set; }

        public string Currency { get; set; } 

        public WalletStatus WalletStatus { get; set; }  

        public bool KycVerified { get; set; }  

        public DateTime CreatedAt { get; set; }
    }
}
