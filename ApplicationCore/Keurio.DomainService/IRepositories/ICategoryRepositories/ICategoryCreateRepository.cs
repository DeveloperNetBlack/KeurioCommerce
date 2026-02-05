using Keurio.DomainModel.Model;

namespace Keurio.DomainService.IRepositories.ICategoryRepositories
{
    public interface ICategoryCreateRepository
    {
        Task<int> CreateAsync(Category Model, CancellationToken CancellationToken);
    }
}
