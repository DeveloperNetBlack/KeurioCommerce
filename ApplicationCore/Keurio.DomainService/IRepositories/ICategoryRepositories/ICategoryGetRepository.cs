using Keurio.DomainModel.Dtos.Category;

namespace Keurio.DomainService.IRepositories.ICategoryRepositories
{
    public interface ICategoryGetRepository
    {
        Task<CategoryGetResponseDto?> GetAsync(int CategoryId, CancellationToken CancellationToken);
    }
}
