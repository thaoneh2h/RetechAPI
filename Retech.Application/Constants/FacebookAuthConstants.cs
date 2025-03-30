namespace Retech.Application.Constants;

public static class FacebookAuthConstants
{
    public const string TokenValidationUrl =
        "https://graph.facebook.com/debug_token?input_token={0}&access_token={1}|{2}";

    public const string GetUserInfoUrl =
        "https://graph.facebook.com/me?fields=id,email,first_name,last_name,picture&access_token={0}";
}
