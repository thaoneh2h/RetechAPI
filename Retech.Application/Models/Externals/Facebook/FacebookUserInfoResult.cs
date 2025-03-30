using Newtonsoft.Json;

namespace Retech.Application.Models.Externals.Facebook;

public class FacebookUserInfoResult
{
    [JsonProperty("first_name")]
    public string FirstName { get; set; } = string.Empty;
    [JsonProperty("last_name")]
    public string LastName { get; set; } = string.Empty;
    [JsonProperty("picture")]
    public FacebookPicture Picture { get; set; } = null!;
    [JsonProperty("email")]
    public string Email { get; set; } = string.Empty;
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;
}

public class FacebookPicture
{
    [JsonProperty("data")]
    public FacebookPictureData? Data { get; set; }
}

public class FacebookPictureData
{
    [JsonProperty("height")]
    public long Height { get; set; }
    [JsonProperty("is_silhouette")]
    public bool IsSilhouette { get; set; }
    [JsonProperty("url")]
    public Uri? Url { get; set; }
    [JsonProperty("width")]
    public string? Width { get; set; }
}
