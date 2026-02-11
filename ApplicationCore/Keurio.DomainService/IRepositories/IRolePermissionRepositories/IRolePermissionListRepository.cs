using Keurio.DomainModel.Dtos.RolePermission;

namespace Keurio.DomainService.IRepositories.IRolePermissionRepositories
{
    public interface IRolePermissionListRepository
    {
        Task<List<RolePermissionListResponseDto>> ListAsync(int UserID, int CompanyID, CancellationToken CancellationToken = default);
    }
}
