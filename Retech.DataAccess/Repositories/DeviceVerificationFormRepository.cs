using Microsoft.EntityFrameworkCore;
using Retech.Core.Models;
using Retech.DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories
{
    public class DeviceVerificationFormRepository : IDeviceVerificationFormRepository
    {
        private readonly AppDbContext _context;

        public DeviceVerificationFormRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DeviceVerificationForm deviceVerificationForm)
        {
            await _context.DeviceVerificationForm.AddAsync(deviceVerificationForm);
            await _context.SaveChangesAsync();
        }

        public async Task<DeviceVerificationForm> GetByProductIdAsync(Guid productId)
        {
            return await _context.DeviceVerificationForm
                                 .FirstOrDefaultAsync(dvf => dvf.ProductId == productId);
        }
    }
}
