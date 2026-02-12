using Keurio.DomainModel.Dtos.Constant;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.ConstantFeatures.Queries.ConstantList
{
    public record struct ConstantListQueryRequest
    (
      string ConstantClass
    ) : IRequest<MsgResponse<List<ConstantListResponseDto>>>;
}
