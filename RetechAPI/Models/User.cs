namespace RetechAPI.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserRole { get; set; }  // Enum: Buyer, Seller, Exchange Staff, Admin
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }  // Enum: Male, Female, Other
        public DateTime BirthDate { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }  // Enum: Active, Suspended
        public float Rating { get; set; }
        public bool KycVerified { get; set; } = false;

    }
}
