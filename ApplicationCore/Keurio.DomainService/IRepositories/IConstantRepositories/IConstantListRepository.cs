using Keurio.DomainModel.Dtos.Constant;

namespace Keurio.DomainService.IRepositories.IConstantRepositories
{
    public interface IConstantListRepository
    {
        Task<List<ConstantListResponseDto>> ListAsync(string ConstantClass, CancellationToken CancellationToken = default);
    }
}
