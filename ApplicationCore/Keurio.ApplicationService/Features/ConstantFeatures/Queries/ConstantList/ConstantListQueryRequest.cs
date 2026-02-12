using Keurio.DomainModel.Dtos.Constant;
using Keurio.DomainService.IRepositories.IConstantRepositories;
using Keurio.DomainService.IServices;
using Keurio.Infrastructure.CrossCutting.Constants;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.ConstantFeatures.Queries.ConstantList
{
    internal class ConstantListQueryHandler : IRequestHandler<ConstantListQueryRequest, MsgResponse<List<ConstantListResponseDto>>>
    {
        private readonly IMessageService MessageService;
        private readonly IConstantListRepository ConstantListRepository;
        public ConstantListQueryHandler(
            IMessageService MessageService,
            IConstantListRepository ConstantListRepository)
        {
            this.ConstantListRepository = ConstantListRepository;
            this.MessageService = MessageService;
        }

        public async Task<MsgResponse<List<ConstantListResponseDto>>> Handle(ConstantListQueryRequest Request, CancellationToken CancellationToken)
        {
            var MsgResponse = new MsgResponse<List<ConstantListResponseDto>>();
            MsgResponse.Type = MessageTypeConst.QUERY;
            MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_RESULT);
            MsgResponse.Data = await ConstantListRepository.ListAsync(Request.ConstantClass, CancellationToken);
            if (!MsgResponse.Data.Any())
            {
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_EMPTY);
            }
            return MsgResponse;
        }
    }
}
