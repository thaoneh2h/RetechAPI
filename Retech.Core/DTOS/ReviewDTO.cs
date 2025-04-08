using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.DTOS
{
    public class ReviewDTO
    {
        public Guid ReviewId { get; set; }
        public Guid ReviewerId { get; set; }
        public Guid RevieweeId { get; set; }
        public Guid OrderId { get; set; }
        public string Comment { get; set; }
        public float Rating { get; set; }
        public DateTime CreatedAt { get; set; }

        // Optional: Thêm thông tin người dùng nếu cần
        public string ReviewerName { get; set; }
        public string RevieweeName { get; set; }
    }

    public class CreateReviewDTO
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public float Rating { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters")]
        public string Comment { get; set; }
    }

    public class UpdateReviewDTO
    {
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public float? Rating { get; set; }

        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters")]
        public string Comment { get; set; }
    }
}
