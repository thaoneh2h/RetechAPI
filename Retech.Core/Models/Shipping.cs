using System.ComponentModel.DataAnnotations;

namespace Retech.Core.Models
{
    public class Shipping
    {
        [Key]
        public Guid ShippingId { get; set; }
        public Guid OrderId { get; set; } // Liên kết với đơn hàng
        public Guid ThirdPartyProviderId { get; set; } // Nhà vận chuyển
        public Guid UserAddressId { get; set; }
        public string ShippingStatus { get; set; } // enum Pending, In Transit, Delivered, Failed
        public string TrackingNumber { get; set; } // Mã theo dõi
        public DateTime EstimatedDeliveryDate { get; set; } // Ngày giao dự kiến
        public DateTime? ActualDeliveryDate { get; set; } // Ngày giao thực tế (nullable nếu chưa giao)
        public decimal ShippingFee { get; set; } // Phí vận chuyển
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Mặc định khi tạo
        // Relationships
        public ThirdPartyProvider ThirdPartyProvider { get; set; }
        public Order Order { get; set; }
        public UserAddress UserAddress { get; set; }
    }
}
