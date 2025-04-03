using Retech.Core.DTOS;
using Retech.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.DataAccess.Repositories.Interfaces;

public interface IUserAddressRepository
{
    Task<IEnumerable<UserAddress>> GetAllAsync();
    Task<UserAddress> GetByIdAsync(Guid id);
    Task AddAsync(UserAddress address);
    Task UpdateAsync(UserAddress address);
    Task DeleteAsync(Guid id);
}
