using Keurio.DomainModel.Dtos.Ubigeo;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.UbigeoFeatures.Queries.UbigeoListByUbigeoClass
{
    public record struct UbigeoListByUbigeoClassQueryRequest(
        int UbigeoClass
    ) : IRequest<MsgResponse<List<UbigeoListByUbigeoClassResponseDto>>>;
}
