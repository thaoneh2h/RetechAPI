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
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository _voucherRepository;

        public VoucherService(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }

        public async Task AddVoucherAsync(VoucherDTO voucherDto)
        {
            var voucher = new Voucher
            {
                VoucherId = Guid.NewGuid(),
                UserId = voucherDto.UserId,
                VoucherCode = voucherDto.VoucherCode,
                DiscountValue = voucherDto.DiscountValue,
                ValidTo = voucherDto.ValidTo,
                VoucherStatus = VoucherStatus.Active  // Set default as Active
            };

            await _voucherRepository.AddAsync(voucher);
        }

        public async Task<ResponseVoucherDTO> GetVoucherByIdAsync(Guid voucherId)
        {
            var voucher = await _voucherRepository.GetByIdAsync(voucherId);
            if (voucher == null) return null;

            return new ResponseVoucherDTO
            {
                VoucherId = voucher.VoucherId,
                UserId = voucher.UserId,
                VoucherCode = voucher.VoucherCode,
                DiscountValue = voucher.DiscountValue,
                ValidTo = voucher.ValidTo,
                VoucherStatus = voucher.VoucherStatus
            };
        }

        public async Task<IEnumerable<ResponseVoucherDTO>> GetAllVouchersByUserIdAsync(Guid userId)
        {
            var vouchers = await _voucherRepository.GetAllByUserIdAsync(userId);
            return vouchers.Select(v => new ResponseVoucherDTO
            {
                VoucherId = v.VoucherId,
                UserId = v.UserId,
                VoucherCode = v.VoucherCode,
                DiscountValue = v.DiscountValue,
                ValidTo = v.ValidTo,
                VoucherStatus = v.VoucherStatus
            }).ToList();
        }

        public async Task<IEnumerable<ResponseVoucherDTO>> GetAllVouchersAsync()
        {
            var vouchers = await _voucherRepository.GetAllAsync();
            return vouchers.Select(v => new ResponseVoucherDTO
            {
                VoucherId = v.VoucherId,
                UserId = v.UserId,
                VoucherCode = v.VoucherCode,
                DiscountValue = v.DiscountValue,
                ValidTo = v.ValidTo,
                VoucherStatus = v.VoucherStatus
            }).ToList();
        }

        public async Task UpdateVoucherAsync(Guid voucherId, VoucherDTO voucherDto)
        {
            var voucher = await _voucherRepository.GetByIdAsync(voucherId);
            if (voucher != null)
            {
                voucher.VoucherCode = voucherDto.VoucherCode;
                voucher.DiscountValue = voucherDto.DiscountValue;
                voucher.ValidTo = voucherDto.ValidTo;

                if (voucher.ValidTo < DateTime.UtcNow)
                {
                    voucher.VoucherStatus = VoucherStatus.Expired;  // Update status if expired
                }

                await _voucherRepository.UpdateAsync(voucher);
            }
        }

        public async Task DeleteVoucherAsync(Guid voucherId)
        {
            await _voucherRepository.DeleteAsync(voucherId);
        }

        public async Task UpdateVoucherStatusAsync(Guid voucherId)
        {
            var voucher = await _voucherRepository.GetByIdAsync(voucherId);
            if (voucher != null && voucher.ValidTo < DateTime.UtcNow)
            {
                voucher.VoucherStatus = VoucherStatus.Expired;
                await _voucherRepository.UpdateAsync(voucher);
            }
        }
        public async Task<IEnumerable<ResponseVoucherDTO>> GetAllActiveVouchersAsync()
        {
            var vouchers = await _voucherRepository.GetAllActiveVouchersAsync();
            return vouchers.Select(v => new ResponseVoucherDTO
            {
                VoucherId = v.VoucherId,
                UserId = v.UserId,
                VoucherCode = v.VoucherCode,
                DiscountValue = v.DiscountValue,
                ValidTo = v.ValidTo,
                VoucherStatus = v.VoucherStatus
            }).ToList();
        }

        public async Task<IEnumerable<ResponseVoucherDTO>> GetAllExpiredVouchersAsync()
        {
            var vouchers = await _voucherRepository.GetAllExpiredVouchersAsync();
            return vouchers.Select(v => new ResponseVoucherDTO
            {
                VoucherId = v.VoucherId,
                UserId = v.UserId,
                VoucherCode = v.VoucherCode,
                DiscountValue = v.DiscountValue,
                ValidTo = v.ValidTo,
                VoucherStatus = v.VoucherStatus
            }).ToList();
        }
    }
}
