using Retech.Core.Attributes;
namespace Retech.Application.Common.Email;

[Setting]

public class SmtpSettings
{
    public string Server { get; set; } = string.Empty;

    public int Port { get; set; }

    public string SenderName { get; set; } = string.Empty;

    public string SenderEmail { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string? EmailConfirmationCallbackUrl { get; set; }
}
