using AutoMapper;
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

        public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.UserId = Guid.NewGuid();
            user.RegistrationDate = DateTime.UtcNow;
            user.UserRole = "Staff"; //vì là admin tạo tài khoản thì tài khoản nên role staff

            await _userRepository.AddAsync(user);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateUserAsync(Guid userId, UserDTO updatedUserDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(userId);
            if (existingUser == null)
            {
                throw new Exception("User not found.");
            }

            // Cập nhật từng trường một cách tường minh
            existingUser.UserName = updatedUserDto.UserName;
            existingUser.Email = updatedUserDto.Email;
            existingUser.PhoneNumber = updatedUserDto.PhoneNumber;
            existingUser.Address = updatedUserDto.Address;
            existingUser.Gender = updatedUserDto.Gender;
            existingUser.BirthDate = updatedUserDto.BirthDate;
            existingUser.ProfilePicture = updatedUserDto.ProfilePicture;
            existingUser.UserStatus = updatedUserDto.UserStatus;

            await _userRepository.UpdateAsync(existingUser);

            // Trả về DTO sau khi cập nhật
            var resultDto = new UserDTO
            {
                UserName = existingUser.UserName,
                Email = existingUser.Email,
                PhoneNumber = existingUser.PhoneNumber,
                Address = existingUser.Address,
                Gender = existingUser.Gender,
                BirthDate = existingUser.BirthDate,
                ProfilePicture = existingUser.ProfilePicture,
                UserStatus = existingUser.UserStatus
            };

            return resultDto;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return await _userRepository.DeleteAsync(userId);
        }
    }
}
