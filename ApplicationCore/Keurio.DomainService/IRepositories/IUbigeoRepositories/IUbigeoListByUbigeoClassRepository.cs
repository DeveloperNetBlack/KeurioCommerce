using Keurio.DomainModel.Dtos.Ubigeo;

namespace Keurio.DomainService.IRepositories.IUbigeoRepositories
{
    public interface IUbigeoListByUbigeoClassRepository
    {
        Task<List<UbigeoListByUbigeoClassResponseDto>> ListByUbigeoClassAsync(int UbigeoClass, CancellationToken CancellationToken = default);
    }
}
