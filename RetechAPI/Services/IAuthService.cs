using RetechAPI.DTOS;

namespace RetechAPI.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDTO model);
        Task<string> LoginAsync(LoginDTO model);
    }

}
