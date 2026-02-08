using Keurio.DomainModel.Model;

namespace Keurio.DomainService.IRepositories.ITokenRepositories
{
    public interface ITokenCreateRepository
    {
        Task<int> CreateAsync(Token Model, CancellationToken CancellationToken = default);
    }
}
