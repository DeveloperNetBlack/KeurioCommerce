using Keurio.Presentation.Models;
using Keurio.Presentation.Services;
using Keurio.Presentation.Areas.Security.Models.Role;

namespace Keurio.Presentation.Areas.Security.Services.RoleService
{
    public interface IRoleService
    {
        Task<ApiResponse<object?>> RoleCreate(RoleCreateUpdateRequestModel Request);
        Task<ApiResponse<object?>> RoleUpdate(RoleCreateUpdateRequestModel Request);
        Task<ApiResponse<object?>> RoleChangeState(RoleChangeStateRequestModel Request);
        Task<ApiResponse<RoleGetResponseModel?>> RoleGet(int RoleID);
        Task<ApiResponse<PaginationResultModel<RolePaginationResponseModel>>> RolePagination(RolePaginationRequestModel Request);   
    }
}