using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Retech.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<AuthResponseDTO> RegisterAsync(UserRegisterDTO dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new Exception("Email already registered.");

            var user = new User
            {
                UserId = Guid.NewGuid(),
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                UserName = dto.UserName,
                PhoneNumber = dto.PhoneNumber,
                UserRole = "Customer", // Default role
                RegistrationDate = DateTime.UtcNow,
                UserStatus = "Active",
                KycVerified = false
            };

            await _userRepository.AddAsync(user);
            return GenerateJwtToken(user);
        }

        public async Task<AuthResponseDTO> LoginAsync(UserLoginDTO dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                throw new UnauthorizedAccessException("Invalid credentials");

            return GenerateJwtToken(user);
        }

        private AuthResponseDTO GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(12),
                signingCredentials: creds
            );

            return new AuthResponseDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = user.UserName,
                Role = user.UserRole
            };
        }
    }
}
