using Retech.Application.Constants;
using Retech.Application.Models.Externals.Facebook;
using Newtonsoft.Json;
using Retech.Core.Attributes;
using Retech.Core.Settings;

namespace Retech.Application.Services.Implementations;

[ScopedService]
public class FacebookAuthService(Authentication authentication, IHttpClientFactory httpClientFactory)
    : IFacebookAuthService
{
    public async Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken)
    {
        var formatUrl = string.Format(FacebookAuthConstants.TokenValidationUrl, accessToken,
            authentication.Facebook.AppId, authentication.Facebook.AppSecret);

        var result = await httpClientFactory.CreateClient().GetAsync(formatUrl);

        result.EnsureSuccessStatusCode();

        var responseAsString = await result.Content.ReadAsStringAsync();
        var validationResult = JsonConvert.DeserializeObject<FacebookTokenValidationResult>(responseAsString) ??
                               throw new Exception("Error when get FacebookTokenValidationResult");

        return validationResult;
    }

    public async Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken)
    {
        var formatUrl = string.Format(FacebookAuthConstants.GetUserInfoUrl, accessToken);

        var result = await httpClientFactory.CreateClient().GetAsync(formatUrl);

        result.EnsureSuccessStatusCode();

        var responseAsString = await result.Content.ReadAsStringAsync();
        var validationResult = JsonConvert.DeserializeObject<FacebookUserInfoResult>(responseAsString) ??
                               throw new Exception("Error when get FacebookUserInfoResult");

        return validationResult;
    }
}
