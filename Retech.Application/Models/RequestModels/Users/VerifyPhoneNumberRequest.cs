namespace Retech.Application.Models.RequestModels.Users;
public class VerifyPhoneNumberRequest
{
    public string Token { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}
