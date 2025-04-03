using Retech.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories.Interfaces
{
    public interface IVoucherRepository
    {
        Task<Voucher> GetByIdAsync(Guid voucherId);
        Task<IEnumerable<Voucher>> GetAllByUserIdAsync(Guid userId);
        Task AddAsync(Voucher voucher);
        Task UpdateAsync(Voucher voucher);
        Task DeleteAsync(Guid voucherId);
        Task<Voucher> GetByVoucherCodeAsync(string voucherCode);
        Task<IEnumerable<Voucher>> GetAllActiveVouchersAsync();
        Task<IEnumerable<Voucher>> GetAllExpiredVouchersAsync();
        Task<IEnumerable<Voucher>> GetAllAsync();
    }
}
