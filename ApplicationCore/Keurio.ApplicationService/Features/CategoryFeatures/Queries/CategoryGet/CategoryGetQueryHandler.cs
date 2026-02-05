using Keurio.DomainModel.Dtos.Category;
using Keurio.DomainService.IRepositories.ICategoryRepositories;
using Keurio.DomainService.IServices;
using Keurio.Infrastructure.CrossCutting.Constants;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.CategoryFeatures.Queries.CategoryGet
{
    internal class CategoryGetQueryHandler(
      ICategoryGetRepository CategoryGetRepository,
      IMessageService MessageService
    ) : IRequestHandler<CategoryGetQueryRequest, MsgResponse<CategoryGetResponseDto?>>
    {
        public async Task<MsgResponse<CategoryGetResponseDto?>> Handle(CategoryGetQueryRequest Request, CancellationToken CancellationToken)
        {
            var MsgResponse = new MsgResponse<CategoryGetResponseDto?>();
            
            MsgResponse.Type = MessageTypeConst.QUERY;
            MsgResponse.Data = await CategoryGetRepository.GetAsync(Request.CategoryId, CancellationToken);

            if (MsgResponse.Data is null)
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_EMPTY);
            else
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_RESULT);

            return MsgResponse;
        }
    }
}
