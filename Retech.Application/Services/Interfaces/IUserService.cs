using Retech.Application.Models;
using Retech.Application.Models.RequestModels.Users;
using Retech.Application.Models.ResponeModels.Users;
using Retech.Core.DTOS;
using Retech.Core.Models;
using System.Security.Claims;

namespace Retech.Application.Services
{
    public interface IUserService
    {
        Task<BaseResponseModel> ChangePasswordAsync(Guid userId, ChangePasswordModel changePasswordModel);
        Task<ConfirmEmailResponseModel> ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel);
        Task<CreateUserResponseModel> CreateAsync(CreateUserModel createUserModel);
        Task<UserProfileDTO> GetUserProfileAsync(Guid userId);
        Task LoginCookiesAsync(LoginUserModel loginUserModel);
        Task RefreshToken();
        Task Logout();
        Task LoginGoogle(IEnumerable<Claim> claims);
        Task LoginWithFacebookAsync(string accessToken);
        Task<LoginResponseModel> LoginAsync(LoginUserModel loginUserModel);
        Task<UserResponse> GetDetails(Guid userId);
        Task SendPhoneVerificationCode(SendCodeRequest request, Guid userId);
        Task VerifyPhoneNumber(VerifyPhoneNumberRequest request, Guid userId);
        Task UpdateUserProfileAsync(Guid userId, UserProfileDTO userProfileDTO); // Cập nhật hồ sơ người dùng

        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByNameAsync(string name);
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);

    }
}
