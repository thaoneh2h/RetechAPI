using Retech.Core.DTOS;

namespace Retech.Application.Services.Interfaces
{
    public interface IUserAddressService
    {
        Task<IEnumerable<UserAddressDTO>> GetAllAsync();
        Task<UserAddressDTO> GetByIdAsync(Guid id);
        Task AddAsync(UserAddressDTO dto);
        Task UpdateAsync(UserAddressDTO dto);
        Task DeleteAsync(Guid id);
    }
}
