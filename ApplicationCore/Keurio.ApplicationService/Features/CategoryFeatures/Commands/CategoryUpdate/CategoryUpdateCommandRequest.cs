using Keurio.DomainModel.Enum;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.CategoryFeatures.Commands.CategoryUpdate
{
    public record struct CategoryUpdateCommandRequest
    (
        int CategoryId,
        string CategoryName,
        StateEnum StateId
    ) : IRequest<MsgResponse<object?>>;
}
