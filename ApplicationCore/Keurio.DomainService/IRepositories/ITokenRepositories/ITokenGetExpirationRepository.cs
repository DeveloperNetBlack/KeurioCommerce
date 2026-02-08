using Keurio.DomainModel.Dtos.Token;

namespace Keurio.DomainService.IRepositories.ITokenRepositories
{
    public interface ITokenGetExpirationRepository
    {
        Task<TokenGetExpirationResponseDto?> GetExpirationAsync(TokenGetExpirationResquestDto TokenGetExpirationResquest, CancellationToken CancellationToken = default);
    }
}
