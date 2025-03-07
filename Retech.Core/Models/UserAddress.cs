namespace Retech.Core.Models
{
    public class UserAddress
    {
        public Guid UserAddressId { get; set; } // ID địa chỉ người dùng
        public Guid UserId { get; set; } // Liên kết với người dùng
        public string AddressLine { get; set; } // Số nhà và tên đường
        public string Ward { get; set; } // Phường
        public string District { get; set; } // Quận/Huyện
        public string City { get; set; } // Thành phố/Tỉnh
        public string Country { get; set; }
        public bool IsPrimary { get; set; } // Địa chỉ chính hay không

        // Mối quan hệ với User
        public User User { get; set; }
    }

}
