namespace Retech.Application.Models.ResponeModels.Users
{
    public class UserResponse : BaseResponseModel
    {
        public string UserName { get; set; } = null;
        public string Email { get; set; } = null;
        public string PhoneNumber { get; set; } = null;
        public string Address { get; set; } = null;
        public string Gender { get; set; } = null;
        public string BirthDate { get; set; } = null;
        public string ProfilePicture { get; set; } = null;
        public IList<string>? UserRole { get; set; }

    }
}
