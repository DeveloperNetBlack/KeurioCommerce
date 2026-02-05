using Keurio.DomainModel.Model;

namespace Keurio.DomainService.IRepositories.ICategoryRepositories
{
    public interface  ICategoryChangeStateRepository
    {
        Task<int> ChangeStateAsync(Category Model, CancellationToken CancellationToken);
    }
}
