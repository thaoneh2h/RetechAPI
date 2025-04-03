using Retech.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        Task<E_Wallet> GetByIdAsync(Guid walletId);
        Task<E_Wallet> GetByUserIdAsync(Guid userId);  // Kiểm tra một user chỉ có một ví
        Task<IEnumerable<E_Wallet>> GetAllAsync();
        Task AddAsync(E_Wallet wallet);
        Task UpdateAsync(E_Wallet wallet);
        Task DeleteAsync(Guid walletId);
    }
}
