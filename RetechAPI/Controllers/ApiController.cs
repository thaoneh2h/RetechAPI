using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Retech.Application.Exceptions;

namespace Retech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        protected Guid UserId => Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId)
        ? userId
        : throw new UnauthorizedException("Resource required login");
    }
}
