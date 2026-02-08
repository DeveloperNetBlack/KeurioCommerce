using Keurio.DomainModel.Model;
using Keurio.DomainService.IRepositories.ICategoryRepositories;

namespace Keurio.Infrastructure.DB.SQLSERVER.Repositories.CategoryRepositories
{
    internal class CategoryValidateRepository : ICategoryValidateRepository
    {
        public Task<string> ValidateAsync(Category Model, CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
