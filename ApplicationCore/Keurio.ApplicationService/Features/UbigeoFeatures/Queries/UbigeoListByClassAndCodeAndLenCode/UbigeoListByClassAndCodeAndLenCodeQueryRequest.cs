using Keurio.DomainModel.Dtos.Ubigeo;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.UbigeoFeatures.Queries.UbigeoListByClassAndCodeAndLenCode
{
    public record UbigeoListByClassAndCodeAndLenCodeQueryRequest(
        int UbigeoClass,
        string UbigeoCode,
        int LenUbigeoCode
    ) : IRequest<MsgResponse<List<UbigeoListByClassAndCodeAndLenCodeResponseDto>>>;
}
