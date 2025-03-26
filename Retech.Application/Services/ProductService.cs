using AutoMapper;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> SearchProductsAsync(string keyword, decimal? minPrice, decimal? maxPrice, string condition, string brand)
        {
            // Call the repository method to fetch the data
            var products = await _productRepository.SearchProductsAsync(keyword, minPrice, maxPrice, condition, brand);

            // Map to DTOs before returning the result
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> CreateProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> UpdateProductAsync(Guid productId, ProductDTO productDto)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) return null;

            _mapper.Map(productDto, product);
            await _productRepository.UpdateAsync(product);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) return false;

            await _productRepository.DeleteAsync(product);
            return true;
        }

        public async Task<ProductDTO> GetProductByIdAsync(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            return product == null ? null : _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(string category)
        {
            var products = await _productRepository.GetByCategoryAsync(category);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            // Fetch all products from the repository
            var products = await _productRepository.GetAllAsync();

            // Map products to ProductDTO
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }








    }
}
