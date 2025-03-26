using Retech.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<Product> GetByIdAsync(Guid productId);
        Task<IEnumerable<Product>> GetByCategoryAsync(string category);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task<IEnumerable<Product>> SearchProductsAsync(string keyword, decimal? minPrice, decimal? maxPrice, string condition, string brand);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
