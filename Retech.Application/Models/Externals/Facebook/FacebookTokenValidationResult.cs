using Newtonsoft.Json;

namespace Retech.Application.Models.Externals.Facebook;

public class FacebookTokenValidationData
{
    [JsonProperty("app_id")]
    public long AppId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Application { get; set; } = string.Empty;
    [JsonProperty("expires_at")]
    public long ExpiresAt { get; set; }
    [JsonProperty("is_valid")]
    public bool IsValid { get; set; }
    [JsonProperty("user_id")]
    public long UserId { get; set; }
}

public class FacebookTokenValidationResult
{
    public FacebookTokenValidationData Data { get; set; } = null!;
}
