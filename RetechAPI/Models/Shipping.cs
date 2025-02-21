namespace RetechAPI.Models
{
    public class Shipping
    {
        public Guid ShippingId { get; set; }
        public Guid OrderId { get; set; } // Liên kết với đơn hàng
        public Guid ThirdPartyProviderId { get; set; } // Nhà vận chuyển
        public Guid ShippingStatus { get; set; } // enum Pending, In Transit, Delivered, Failed
        public string TrackingNumber { get; set; } // Mã theo dõi
        public DateTime EstimatedDeliveryDate { get; set; } // Ngày giao dự kiến
        public DateTime? ActualDeliveryDate { get; set; } // Ngày giao thực tế (nullable nếu chưa giao)
        public decimal ShippingFee { get; set; } // Phí vận chuyển
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Mặc định khi tạo
    }
}
