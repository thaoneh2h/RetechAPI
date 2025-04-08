using AutoMapper;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public ReviewService(
            IReviewRepository reviewRepository,
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public async Task<ReviewDTO> GetByIdAsync(Guid id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            return _mapper.Map<ReviewDTO>(review);
        }

        public async Task<ReviewDTO> CreateAsync(Guid userId, CreateReviewDTO dto)
        {
            // Kiểm tra order có tồn tại và thuộc về user
            var order = await _orderRepository.GetByIdAsync(dto.OrderId);
            if (order == null) throw new Exception("Order not found");

            // Kiểm tra user có phải là buyer trong order
            if (order.BuyerId != userId)
                throw new Exception("Only buyer can create review for this order");

            // Kiểm tra đã có review cho order này chưa
            if (await _reviewRepository.ExistsForOrderAsync(dto.OrderId))
                throw new Exception("Review already exists for this order");

            var review = _mapper.Map<Review>(dto);
            review.ReviewId = Guid.NewGuid();
            review.ReviewerId = userId;
            review.RevieweeId = order.SellerId;
            review.CreatedAt = DateTime.UtcNow;

            await _reviewRepository.AddAsync(review);
            return _mapper.Map<ReviewDTO>(review);
        }

        public async Task<ReviewDTO> UpdateAsync(Guid reviewId, Guid userId, UpdateReviewDTO dto)
        {
            var review = await _reviewRepository.GetByIdAsync(reviewId);
            if (review == null) throw new Exception("Review not found");

            // Chỉ reviewer mới được sửa review
            if (review.ReviewerId != userId)
                throw new Exception("Only reviewer can update this review");

            if (dto.Rating.HasValue) review.Rating = dto.Rating.Value;
            if (!string.IsNullOrEmpty(dto.Comment)) review.Comment = dto.Comment;

            await _reviewRepository.UpdateAsync(review);
            return _mapper.Map<ReviewDTO>(review);
        }

        public async Task<bool> DeleteAsync(Guid reviewId, Guid userId)
        {
            var review = await _reviewRepository.GetByIdAsync(reviewId);
            if (review == null) return false;

            // Chỉ reviewer hoặc admin mới được xóa
            if (review.ReviewerId != userId)
                throw new Exception("Only reviewer can delete this review");

            return await _reviewRepository.DeleteAsync(reviewId);
        }
    }
}
