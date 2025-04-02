using Retech.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<RequestProductDTO> CreateProductAsync(RequestProductDTO requestproductDto);
        Task<RequestProductDTO> UpdateProductAsync(Guid productId, RequestProductDTO requestproductDto);
        Task<bool> DeleteProductAsync(Guid productId);
        Task<ProductDTO> GetProductByIdAsync(Guid productId);
        Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(string category);
        Task<IEnumerable<ProductDTO>> SearchProductsAsync(string keyword, decimal? minPrice, decimal? maxPrice, string condition, string brand);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    }

}
