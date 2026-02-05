using Keurio.DomainModel.Model;
using Keurio.DomainService.IRepositories.ICategoryRepositories;
using Keurio.DomainService.IServices;
using Keurio.Infrastructure.CrossCutting.Constants;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.CategoryFeatures.Commands.CategoryChangeState
{
    internal class CategoryChangeStateCommandHandler(
        ICategoryChangeStateRepository CategoryChangeStateRepository,
        ICurrentSessionService CurrentSessionService,
        IMessageService MessageService
        ) : IRequestHandler<CategoryChangeStateCommandRequest, MsgResponse<object?>>
    {
        public async Task<MsgResponse<object?>> Handle(CategoryChangeStateCommandRequest request, CancellationToken cancellationToken)
        {
            var MsgResponse = new MsgResponse<object?>();

            try
            {
                var Model = Category.ChangeState(
                    request.CategoryId,
                    request.StateId,
                    CurrentSessionService.UserID
                    );

                var RecordAffected = await CategoryChangeStateRepository.ChangeStateAsync(Model, cancellationToken);

                if(RecordAffected > 0)
                {
                    MsgResponse.Type = MessageTypeConst.SUCCESS;
                    MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.SATISFACTORY_CHANGE); 
                }
                else
                {
                    MsgResponse.Type = MessageTypeConst.ERROR;
                    MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.ERROR_CHANGE); 
                }
            }
            catch (Exception ex)
            {
                MsgResponse.Type = MessageTypeConst.ERROR;
                MsgResponse.Message = $"{MessageService.GetMessageResult(MessageDescriptionConst.ERROR_OPERATION)}:{ex.Message}";
            }

            return MsgResponse;
        }
    }
}
