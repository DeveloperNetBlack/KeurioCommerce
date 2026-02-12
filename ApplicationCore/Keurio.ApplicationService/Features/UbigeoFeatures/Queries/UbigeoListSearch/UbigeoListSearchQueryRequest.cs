using Keurio.DomainModel.Dtos.Ubigeo;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.UbigeoFeatures.Queries.UbigeoListSearch
{
    public record UbigeoListSearchQueryRequest(
       int UbigeoClassContinent,
       string UbigeoName
    ) : IRequest<MsgResponse<List<UbigeoListSearchResponseDto>>>;
}
