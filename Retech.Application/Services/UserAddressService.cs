using AutoMapper;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Application.Services;

public class UserAddressService : IUserAddressService
{
    private readonly IUserAddressRepository _repository;
    private readonly IMapper _mapper;

    public UserAddressService(IUserAddressRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserAddressDTO>> GetAllAsync()
    {
        var addresses = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserAddressDTO>>(addresses);
    }

    public async Task<UserAddressDTO> GetByIdAsync(Guid id)
    {
        var address = await _repository.GetByIdAsync(id);
        return _mapper.Map<UserAddressDTO>(address);
    }

    public async Task AddAsync(UserAddressDTO dto)
    {
        var address = _mapper.Map<UserAddress>(dto);
        await _repository.AddAsync(address);
    }

    public async Task UpdateAsync(UserAddressDTO dto)
    {
        var address = _mapper.Map<UserAddress>(dto);
        await _repository.UpdateAsync(address);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
