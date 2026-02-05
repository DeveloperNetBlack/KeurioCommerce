using Keurio.Presentation.Models.RolePermission;
using Keurio.Presentation.Services;

namespace Keurio.Presentation.Services.RolePermissionService
{
    public interface IRolePermissionService
    {
        Task<ApiResponse<List<RolePermissionListResponseModel>>> RolePermissionList(RolePermissionListRequestModel Request);
    }
}