using Retech.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services.Interfaces
{
    public interface IWalletService
    {
        // Thêm mới ví (chỉ cần UserId, các thuộc tính còn lại được set mặc định)
        Task AddWalletAsync(E_WalletDTO walletDto);

        // Lấy ví theo ID
        Task<ResponseWalletDTO> GetWalletByIdAsync(Guid walletId);

        // Lấy ví của người dùng
        Task<ResponseWalletDTO> GetWalletByUserIdAsync(Guid userId);

        // Lấy tất cả ví
        Task<IEnumerable<ResponseWalletDTO>> GetAllWalletsAsync();

        // Cập nhật ví
        Task UpdateWalletAsync(Guid walletId, ResponseWalletDTO walletDto);

        // Xóa ví
        Task DeleteWalletAsync(Guid walletId);
    }
}
