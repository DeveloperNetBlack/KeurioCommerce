using Keurio.DomainModel.Enum;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.CategoryFeatures.Commands.CategoryChangeState
{
    public record struct CategoryChangeStateCommandRequest
    (
        int CategoryId,
        StateEnum StateId
    ) : IRequest<MsgResponse<object?>>;
}
