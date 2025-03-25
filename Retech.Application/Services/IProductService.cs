using Retech.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services
{
    public interface IProductService
    {
        Task<ProductDTO> CreateProductAsync(ProductDTO productDto);
        Task<ProductDTO> UpdateProductAsync(Guid productId, ProductDTO productDto);
        Task<bool> DeleteProductAsync(Guid productId);
        Task<ProductDTO> GetProductByIdAsync(Guid productId);
        Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(string category);
    }

}
