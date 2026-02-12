using Keurio.DomainModel.Dtos.Ubigeo;

namespace Keurio.DomainService.IRepositories.IUbigeoRepositories
{
    public interface IUbigeoListSearchRepository
    {
        Task<List<UbigeoListSearchResponseDto>> ListSearchAsync(int UbigeoClassContinent, string UbigeoName, CancellationToken CancellationToken = default);
    }
}
