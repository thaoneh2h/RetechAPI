using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class UpdateUserDTO
    {
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ProfilePicture { get; set; }
        public string? UserStatus { get; set; }
        public string? UserRole { get; set; }
        public bool? KycVerified { get; set; }
    }
}
