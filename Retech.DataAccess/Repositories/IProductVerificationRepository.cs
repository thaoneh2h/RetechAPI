using Retech.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories
{
    public interface IProductVerificationRepository
    {
        Task AddAsync(ProductVerification productVerification);
        Task<ProductVerification> GetByProductIdAsync(Guid productId);
    }

    
}
