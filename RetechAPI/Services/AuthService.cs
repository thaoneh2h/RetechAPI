using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RetechAPI.DTOS;
using RetechAPI.Models;
using RetechAPI.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace RetechAPI.Services
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

        // Đăng ký người dùng mới
        public async Task<string> RegisterAsync(RegisterDTO model)
        {
            // Kiểm tra nếu người dùng đã tồn tại
            var existingUser = await _userRepository.GetUserByNameAsync(model.UserName);
            if (existingUser != null)
            {
                throw new Exception("Username is already taken");
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password) // Mã hóa mật khẩu
            };

            await _userRepository.AddUserAsync(user);

            return GenerateJwtToken(user);
        }

        // Đăng nhập người dùng
        public async Task<string> LoginAsync(LoginDTO model)
        {
            var user = await _userRepository.GetUserByNameAsync(model.UserName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            return GenerateJwtToken(user);
        }

        // Tạo JWT token
        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expirationInMinutes = int.Parse(jwtSettings["ExpirationInMinutes"]);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(expirationInMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
