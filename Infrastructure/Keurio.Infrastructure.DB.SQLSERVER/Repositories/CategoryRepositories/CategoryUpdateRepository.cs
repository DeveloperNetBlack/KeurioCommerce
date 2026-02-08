using Keurio.DomainModel.Model;
using Keurio.DomainService.IRepositories.ICategoryRepositories;

namespace Keurio.Infrastructure.DB.SQLSERVER.Repositories.CategoryRepositories
{
    internal class CategoryUpdateRepository : ICategoryUpdateRepository
    {
        public Task<int> UpdateAsync(Category Model, CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
