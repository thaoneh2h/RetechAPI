namespace Retech.Application.Models.RequestModels.Users
{
    public class ConfirmEmailModel
    {
        public string UserId { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
    }

    public class ConfirmEmailResponseModel
    {
        public bool Confirmed { get; set; }
    }
}
