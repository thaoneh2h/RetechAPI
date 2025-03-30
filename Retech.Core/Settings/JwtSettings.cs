using Retech.Core.Attributes;

namespace Retech.Core.Settings
{
    [Setting]
    public class JwtSettings
    {
        public string? Issuer { get; init; }
        public string? Audience { get; init; }
        public string SecretKey { get; init; } = string.Empty;
        public bool ValidateAudience { get; init; }
        public bool ValidateIssuer { get; init; }
        public bool ValidateIssuerSigningKey { get; init; }
        public bool ValidateLifetime { get; init; }
        public int AccessTokenLifetimeInMinutes { get; init; }
        public int RefreshTokenLifetimeInDays { get; init; }
    }
}
