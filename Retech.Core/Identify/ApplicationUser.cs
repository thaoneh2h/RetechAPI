using Microsoft.AspNetCore.Identity;
using Retech.Core.Constants;
using Retech.Core.Models.Enums;

namespace Retech.Core.Identify;

public class ApplicationUser : IdentityUser<Guid>/*,ISoftDelete<Guid> cái này implement chưa hết...*/
{
    public string UserName { get; set; } = null!;
    public string UserRole { get; set; } = UserRoleConstants.SELLER;
    public string? ProfilePicture { get; set; }
    public Gender Gender { get; set; } = Gender.Other;
    public string? GeneratedPassword { get; set; }
    public string? Password { get; set; }
    //public ICollection<TourRequest>? TourRequests { get; set; }
    //public ICollection<Proposal>? Proposals { get; set; }
    //public ICollection<UserRole>? UserRoles { get; set; }
    //fixing here....
    //public ICollection<RefreshToken>? RefreshTokens { get; set; }
    //public ICollection<UserNotification>? UserNotifications { get; set; }
    //public ICollection<StaffOrder>? ServeAsTourGuideInTours { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid DeletedBy { get; set; }
}
