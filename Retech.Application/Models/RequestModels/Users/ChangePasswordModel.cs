namespace Retech.Application.Models.RequestModels.Users;

public class ChangePasswordModel
{
    public string OldPassword { get; set; } = null!;

    public string NewPassword { get; set; } = null!;
}
