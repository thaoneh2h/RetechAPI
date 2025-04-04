using System.ComponentModel.DataAnnotations;

namespace Retech.Core.DTOS
{
    public class UserRegisterDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }
    }

    public class UserLoginDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class AuthResponseDTO
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
