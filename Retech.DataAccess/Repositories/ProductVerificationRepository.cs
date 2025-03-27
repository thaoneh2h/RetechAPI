using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using Retech.DataAccess.DataContext;
using Retech.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories
{
    public class ProductVerificationRepository : IProductVerificationRepository
    {
        private readonly AppDbContext _context;

        public ProductVerificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductVerification productVerification)
        {
            await _context.ProductVerification.AddAsync(productVerification);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductVerification> GetByProductIdAsync(Guid productId)
        {
            return await _context.ProductVerification
                                 .FirstOrDefaultAsync(pv => pv.ProductId == productId);
        }
    }

    
}
