using Keurio.DomainModel.Model;
using Keurio.DomainService.IRepositories.ICategoryRepositories;

namespace Keurio.Infrastructure.DB.SQLSERVER.Repositories.CategoryRepositories
{
    internal class CategoryCreateRepository : ICategoryCreateRepository
    {
        public Task<int> CreateAsync(Category Model, CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
