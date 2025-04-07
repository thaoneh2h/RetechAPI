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

        public AdminService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(string? role = null)
        {
            var users = await _userRepository.GetAllAsync();
            return role != null
                ? users.Where(u => u.UserRole != null && u.UserRole.Equals(role, StringComparison.OrdinalIgnoreCase))
                : users;
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.UserId = Guid.NewGuid();
            user.RegistrationDate = DateTime.UtcNow;
            user.UserRole = "Staff";
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> UpdateUserAsync(Guid userId, User updatedUser)
        {
            var existingUser = await _userRepository.GetByIdAsync(userId);
            if (existingUser == null) throw new Exception("User not found.");

            // Cập nhật các field cần thiết
            existingUser.UserName = updatedUser.UserName;
            existingUser.Email = updatedUser.Email;
            existingUser.PhoneNumber = updatedUser.PhoneNumber;
            existingUser.Address = updatedUser.Address;
            existingUser.Gender = updatedUser.Gender;
            existingUser.BirthDate = updatedUser.BirthDate;
            existingUser.ProfilePicture = updatedUser.ProfilePicture;
            existingUser.UserStatus = updatedUser.UserStatus;
            existingUser.KycVerified = updatedUser.KycVerified;

            await _userRepository.UpdateAsync(existingUser);
            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return await _userRepository.DeleteAsync(userId);
        }
    }
}
