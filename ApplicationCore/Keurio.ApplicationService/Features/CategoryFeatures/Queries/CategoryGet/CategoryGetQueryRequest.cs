using Keurio.DomainModel.Dtos.Category;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.CategoryFeatures.Queries.CategoryGet
{
    public record struct CategoryGetQueryRequest(
       int CategoryId
    ) : IRequest<MsgResponse<CategoryGetResponseDto?>>;
}
