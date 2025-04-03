namespace Retech.Shared.Services;

public interface IClaimService
{
    Guid GetUserId();
    IList<string> GetRoles();
    string GetClaim(string key);
}
