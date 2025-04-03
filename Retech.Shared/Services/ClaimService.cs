using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Retech.Shared.Services;

namespace Retech.Shared.Services.Implementations;

public class ClaimService : IClaimService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ClaimService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetUserId()
    {
        var nameId = GetClaim(ClaimTypes.NameIdentifier);
        if (Guid.TryParse(nameId, out var newid)) return newid;
        return Guid.Empty;
    }

    public string GetClaim(string key)
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirst(key)?.Value ?? string.Empty;
    }

    public IList<string> GetRoles()
    {
        var roles = _httpContextAccessor.HttpContext?.User?.Claims?.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();
        return roles ?? new List<string>();
    }
}
