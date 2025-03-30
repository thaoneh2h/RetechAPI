using Retech.Application.Helpers;
using Retech.Application.Models.ResponeModels.Users;
using Retech.Application.Models.ResponseModels.Reports;
using Retech.Core.Identify;
using Retech.Core.Models.Enums;

namespace Retech.Application.Services
{
    public interface IAdminService
    {
        Task<PaginationItem<ApplicationUser, UserResponse>> GetUsers(string? name = null, Gender? gender = null, string? username = null, string? email = null, string? phone = null, string? sortOption = null, int? pageIndex = null, int? pageSize = null, string? role = null!);
        Task<UserRoleResponse> GetUserRoleReport();
    }
}
