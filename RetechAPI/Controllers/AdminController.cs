using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Retech.Application.Models.ResponeModels.Users;
using Retech.Application.Models;
using Retech.Core.Constants;
using Retech.Application.Services;
using Retech.Application.Models.ResponseModels.Reports;
using Retech.Application.Helpers;
using Retech.Core.Models.Enums;
using Retech.Core.Identify;

namespace Retech.API.Controllers
{
    [Authorize(Roles = UserRoleConstants.ADMIN)]
    public class AdminController(IAdminService adminService, INotificationService notificationService) : ApiController
    {
        [HttpGet("int")]
        public async Task<IActionResult> GetUserRole()
        {
            return Ok(ApiResult<UserRoleResponse>.Success(await adminService.GetUserRoleReport()));
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers(string? name = null, Gender? gender = null, string? username = null, string? email = null, string? phone = null, string? sortOption = null, int? pageIndex = null, int? pageSize = null, string? role = null!)
        {
            return Ok(ApiResult<PaginationItem<ApplicationUser, UserResponse>>.Success(await adminService.GetUsers(name, gender, username, email, phone, sortOption, pageIndex, pageSize, role)));
        }
    }
}
