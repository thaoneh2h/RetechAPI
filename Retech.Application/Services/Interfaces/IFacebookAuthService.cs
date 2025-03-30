using Retech.Application.Models.Externals.Facebook;

namespace Retech.Application.Services;

public interface IFacebookAuthService
{
    Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken);
    Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken);
}
