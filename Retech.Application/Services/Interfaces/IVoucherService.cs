using Retech.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services.Interfaces
{
    public interface IVoucherService
    {
        Task AddVoucherAsync(VoucherDTO voucherDto);
        Task<ResponseVoucherDTO> GetVoucherByIdAsync(Guid voucherId);
        Task<IEnumerable<ResponseVoucherDTO>> GetAllVouchersByUserIdAsync(Guid userId);
        Task<IEnumerable<ResponseVoucherDTO>> GetAllVouchersAsync();
        Task UpdateVoucherAsync(Guid voucherId, VoucherDTO voucherDto);
        Task DeleteVoucherAsync(Guid voucherId);
        Task UpdateVoucherStatusAsync(Guid voucherId);
        Task<IEnumerable<ResponseVoucherDTO>> GetAllActiveVouchersAsync();  
        Task<IEnumerable<ResponseVoucherDTO>> GetAllExpiredVouchersAsync();
    }
}
