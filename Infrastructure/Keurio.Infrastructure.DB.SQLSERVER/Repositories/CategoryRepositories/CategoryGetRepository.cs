using Keurio.DomainModel.Dtos.Category;
using Keurio.DomainService.IRepositories.ICategoryRepositories;

namespace Keurio.Infrastructure.DB.SQLSERVER.Repositories.CategoryRepositories
{
    internal class CategoryGetRepository : ICategoryGetRepository
    {
        public Task<CategoryGetResponseDto?> GetAsync(int CategoryId, CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
