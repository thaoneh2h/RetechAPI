using Retech.Core.DTOS;
using System.Threading.Tasks;

namespace Retech.Application.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> RegisterAsync(UserRegisterDTO dto);
        Task<AuthResponseDTO> LoginAsync(UserLoginDTO dto);

    }
}
