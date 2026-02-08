using Keurio.DomainModel.Model;

namespace Keurio.DomainService.IRepositories.ITokenRepositories
{
    public interface ITokenUpdateRevocationRepository
    {
        Task<int> UpdateRevocationAsync(Token Model, CancellationToken CancellationToken = default);
    }
}
