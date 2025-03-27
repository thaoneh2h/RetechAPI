using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using Retech.DataAccess.DataContext;
using Retech.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(Guid productId)
        {
            return await _context.Product.Include(p => p.Category)
                                         .FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
        {
            return await _context.Product.Where(p => p.Category.ElectronicEquipmentType.Contains(category))
                                         .ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string keyword, decimal? minPrice, decimal? maxPrice, string condition, string brand)
        {
            var productsQuery = _context.Product.Include(p => p.Category).AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                productsQuery = productsQuery.Where(p => p.ProductName.Contains(keyword) || p.Description.Contains(keyword));
            }

            if (minPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.SellingPrice >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.SellingPrice <= maxPrice.Value);
            }

            if (!string.IsNullOrEmpty(condition))
            {
                productsQuery = productsQuery.Where(p => p.Condition == condition);
            }

            if (!string.IsNullOrEmpty(brand))
            {
                productsQuery = productsQuery.Where(p => p.Category.BrandName.Contains(brand));
            }

            var products = await productsQuery.ToListAsync();  // Execute query and load data
            return products;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            // Fetch all products from the database, including the associated category
            return await _context.Product.Include(p => p.Category).ToListAsync();
        }


    }
}
