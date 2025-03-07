using Retech.Core.DTOS;

namespace Retech.Application.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDTO model);
        Task<string> LoginAsync(LoginDTO model);
    }

}
