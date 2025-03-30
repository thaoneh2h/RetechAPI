using Retech.Core.Attributes;

namespace Retech.Core.Settings
{
    [Setting]
    public class Authentication
    {
        public FacebookSettings Facebook { get; set; } = null!;
        public GoogleSettings Google { get; set; } = null!;
    }

    public class FacebookSettings
    {
        public string AppId { get; set; } = null!;
        public string AppSecret { get; set; } = null!;
    }

    public class GoogleSettings
    {
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string UrlCallback { get; set; } = string.Empty;
        public string UrlReturnSuccess { get; set; } = string.Empty;
        public string UrlReturnFail { get; set; } = string.Empty;
    }
}
