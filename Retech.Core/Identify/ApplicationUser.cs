using Microsoft.AspNetCore.Identity;
using Retech.Core.Common;
using Retech.Core.Constants;
using Retech.Core.Models.Enums;

namespace Retech.Core.Identify;

public class ApplicationUser : IdentityUser<Guid>, ISoftDelete<Guid>
{
    public string UserName { get; set; } = null!;
    public string UserRole { get; set; } = UserRoleConstants.SELLER;
    public string? ProfilePicture { get; set; }
    public Gender Gender { get; set; } = Gender.Other;
    public string? GeneratedPassword { get; set; }
    public string? Password { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid DeletedBy { get; set; }
}
