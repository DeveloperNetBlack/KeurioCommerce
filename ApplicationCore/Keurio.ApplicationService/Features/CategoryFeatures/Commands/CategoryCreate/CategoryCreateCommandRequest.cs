using Keurio.DomainModel.Enum;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.CategoryFeatures.Commands.CategoryCreate
{
    public record struct CategoryCreateCommandRequest
     (
        string CategoryCode,
        string CategoryName,
        StateEnum StateId
     ) : IRequest<MsgResponse<object>>;
}
