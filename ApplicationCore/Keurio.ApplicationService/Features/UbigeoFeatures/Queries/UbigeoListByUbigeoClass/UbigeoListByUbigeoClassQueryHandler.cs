using Keurio.DomainModel.Dtos.Ubigeo;
using Keurio.DomainService.IRepositories.IUbigeoRepositories;
using Keurio.DomainService.IServices;
using Keurio.Infrastructure.CrossCutting.Constants;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.UbigeoFeatures.Queries.UbigeoListByUbigeoClass
{
    internal class UbigeoListByUbigeoClassQueryHandler : IRequestHandler<UbigeoListByUbigeoClassQueryRequest, MsgResponse<List<UbigeoListByUbigeoClassResponseDto>>>
    {
        private readonly IMessageService MessageService;
        private readonly IUbigeoListByUbigeoClassRepository UbigeoListByUbigeoClassRepository;
        public UbigeoListByUbigeoClassQueryHandler(
            IMessageService MessageService,
            IUbigeoListByUbigeoClassRepository UbigeoListByUbigeoClassRepository)
        {
            this.UbigeoListByUbigeoClassRepository = UbigeoListByUbigeoClassRepository;
            this.MessageService = MessageService;
        }

        public async Task<MsgResponse<List<UbigeoListByUbigeoClassResponseDto>>> Handle(UbigeoListByUbigeoClassQueryRequest Request, CancellationToken CancellationToken)
        {
            var MsgResponse = new MsgResponse<List<UbigeoListByUbigeoClassResponseDto>>();
            MsgResponse.Type = MessageTypeConst.QUERY;
            MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_RESULT);
            MsgResponse.Data = await UbigeoListByUbigeoClassRepository.ListByUbigeoClassAsync(Request.UbigeoClass, CancellationToken);
            if (!MsgResponse.Data.Any())
            {
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_EMPTY);
            }
            return MsgResponse;
        }
    }
}
