using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.DataContext;
using Retech.DataAccess.Repositories.Interfaces;

namespace Retech.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AdminService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync(string? role = null)
        {
            var users = await _userRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(role))
            {
                users = users.Where(u => u.UserRole != null &&
                                       u.UserRole.Equals(role, StringComparison.OrdinalIgnoreCase));
            }
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> CreateUserAsync(CreateUserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.UserId = Guid.NewGuid();
            user.RegistrationDate = DateTime.UtcNow;
            user.UserRole = "Staff"; // vì là admin tạo account nên role là staff
            user.UserStatus = "Active";
            user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password); 

            await _userRepository.AddAsync(user);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateUserAsync(Guid userId, UpdateUserDTO updatedUserDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(userId);
            if (existingUser == null)
                throw new Exception("User not found.");

            // Chỉ update các trường được phép
            _mapper.Map(updatedUserDto, existingUser);

            await _userRepository.UpdateAsync(existingUser);
            return _mapper.Map<UserDTO>(existingUser);
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return await _userRepository.DeleteAsync(userId);
        }
    }
}
