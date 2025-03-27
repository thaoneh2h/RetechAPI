using Retech.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories.Interfaces
{
    public interface IDeviceVerificationFormRepository
    {
        Task AddAsync(DeviceVerificationForm deviceVerificationForm);
        Task<DeviceVerificationForm> GetByProductIdAsync(Guid productId);
        Task UpdateAsync(DeviceVerificationForm deviceVerificationForm);
        
        }
}
