using Retech.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> GetByIdAsync(Guid id);
        Task<IEnumerable<Review>> GetAllAsync();
        Task AddAsync(Review review);
        Task UpdateAsync(Review review);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsForOrderAsync(Guid orderId);
    }
}
