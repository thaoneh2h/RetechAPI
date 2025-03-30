namespace Retech.Application.Services;

public interface ISMSService
{
    Task<bool> SendSmsAsync(string to, string message);
}
