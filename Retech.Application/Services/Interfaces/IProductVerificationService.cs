using Retech.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retech.Application.Services.Interfaces
{
    public interface IProductVerificationService
    {
        Task<DeviceVerificationFormDTO> ScheduleVerificationAsync(DeviceVerificationFormDTO verificationRequest);
        Task CompleteVerificationAsync(Guid productId, ProductVerificationDTO verificationResult);
        Task<ProductVerificationDTO> GetVerificationResultAsync(Guid productId);
        Task<IEnumerable<DeviceVerificationFormDTO>> GetAllDeviceVerificationFormAsync();
        Task<IEnumerable<ProductVerificationDTO>> GetAllProductVerificationAsync();
    }
}
