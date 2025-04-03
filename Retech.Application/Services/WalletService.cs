using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.Repositories.Interfaces;
using Retech.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Retech.Core.Models.Enums;

namespace Retech.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        // Thêm ví mới cho người dùng
        public async Task AddWalletAsync(E_WalletDTO walletDto)
        {
            // Kiểm tra xem người dùng đã có ví hay chưa
            var existingWallet = await _walletRepository.GetByUserIdAsync(walletDto.UserId);
            if (existingWallet != null)
                throw new InvalidOperationException("A user can only have one wallet.");

            // Tạo ví mới và set các thuộc tính mặc định
            var wallet = new E_Wallet
            {
                WalletId = Guid.NewGuid(),
                UserId = walletDto.UserId,
                Balance = 0,  // Mặc định là 0
                Currency = "RetechCoin",  // Mặc định là RetechCoin
                WalletStatus = WalletStatus.Active,  // Mặc định là Active
                KycVerified = false,  // Mặc định chưa xác minh KYC
                CreatedAt = DateTime.UtcNow  // Mặc định là thời gian hiện tại
            };

            // Thêm ví vào cơ sở dữ liệu
            await _walletRepository.AddAsync(wallet);
        }

        // Lấy ví theo ID
        public async Task<ResponseWalletDTO> GetWalletByIdAsync(Guid walletId)
        {
            var wallet = await _walletRepository.GetByIdAsync(walletId);
            if (wallet == null) return null;

            return new ResponseWalletDTO
            {
                WalletId = wallet.WalletId,
                UserId = wallet.UserId,
                Balance = wallet.Balance,
                Currency = wallet.Currency,
                WalletStatus = wallet.WalletStatus,
                KycVerified = wallet.KycVerified,
                CreatedAt = wallet.CreatedAt
            };
        }

        // Lấy ví của người dùng theo UserId
        public async Task<ResponseWalletDTO> GetWalletByUserIdAsync(Guid userId)
        {
            var wallet = await _walletRepository.GetByUserIdAsync(userId);
            if (wallet == null) return null;

            return new ResponseWalletDTO
            {
                WalletId = wallet.WalletId,
                UserId = wallet.UserId,
                Balance = wallet.Balance,
                Currency = wallet.Currency,
                WalletStatus = wallet.WalletStatus,
                KycVerified = wallet.KycVerified,
                CreatedAt = wallet.CreatedAt
            };
        }

        // Lấy tất cả ví
        public async Task<IEnumerable<ResponseWalletDTO>> GetAllWalletsAsync()
        {
            var wallets = await _walletRepository.GetAllAsync();
            return wallets.Select(w => new ResponseWalletDTO
            {
                WalletId = w.WalletId,
                UserId = w.UserId,
                Balance = w.Balance,
                Currency = w.Currency,
                WalletStatus = w.WalletStatus,
                KycVerified = w.KycVerified,
                CreatedAt = w.CreatedAt
            }).ToList();
        }

        // Cập nhật ví
        public async Task UpdateWalletAsync(Guid walletId, ResponseWalletDTO walletDto)
        {
            var wallet = await _walletRepository.GetByIdAsync(walletId);
            if (wallet != null)
            {
                wallet.Balance = walletDto.Balance;
                wallet.Currency = walletDto.Currency;
                wallet.KycVerified = walletDto.KycVerified;

                if (walletDto.WalletStatus != WalletStatus.Active)
                {
                    wallet.WalletStatus = WalletStatus.Suspended;  // Ví có thể bị tạm dừng nếu cần
                }

                await _walletRepository.UpdateAsync(wallet);
            }
        }

        // Xóa ví
        public async Task DeleteWalletAsync(Guid walletId)
        {
            await _walletRepository.DeleteAsync(walletId);
        }
    }
}
