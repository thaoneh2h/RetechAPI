using Retech.Application.Common.Email;

namespace Retech.Application.Services;

public interface IEmailService
{
    Task SendEmailAsync(EmailMessage emailMessage);
}
