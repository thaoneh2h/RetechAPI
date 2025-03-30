namespace Retech.Application.Models.RequestModels.Users;

public class CreateUserModel : CreateUserWithNoPasswordRequest
{
    public string Password { get; set; } = null!;
}

public class CreateUserResponseModel : BaseResponseModel
{
}

public class CreateUserWithNoPasswordRequest
{
    public string UserName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Gender { get; set; }

    public string Email { get; set; } = null!;

}
