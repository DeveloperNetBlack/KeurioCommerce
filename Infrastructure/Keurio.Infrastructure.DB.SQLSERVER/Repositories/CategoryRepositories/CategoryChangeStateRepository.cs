using Keurio.DomainModel.Model;
using Keurio.DomainService.IRepositories.ICategoryRepositories;

namespace Keurio.Infrastructure.DB.SQLSERVER.Repositories.CategoryRepositories
{
    internal class CategoryChangeStateRepository : ICategoryChangeStateRepository
    {
        public Task<int> ChangeStateAsync(Category Model, CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
