using Retech.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDTO>> GetAllAsync();
        Task<ReviewDTO> GetByIdAsync(Guid id);
        Task<ReviewDTO> CreateAsync(Guid userId, CreateReviewDTO dto);
        Task<ReviewDTO> UpdateAsync(Guid reviewId, Guid userId, UpdateReviewDTO dto);
        Task<bool> DeleteAsync(Guid reviewId, Guid userId);
    }
}
