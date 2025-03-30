using Retech.Application.Models.ResponeModels.Users;

namespace Retech.Application.Models.RequestModels.Users;

public class LoginUserModel
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}

public class LoginResponseModel
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }

    public UserResponse User { get; set; }
}
