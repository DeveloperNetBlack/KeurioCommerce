using Keurio.DomainModel.Dtos.Ubigeo;
using Keurio.DomainService.IRepositories.IUbigeoRepositories;
using Keurio.DomainService.IServices;
using Keurio.Infrastructure.CrossCutting.Constants;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.UbigeoFeatures.Queries.UbigeoListByClassAndCodeAndLenCode
{
    internal class UbigeoListByClassAndCodeAndLenCodeQueryHandler : IRequestHandler<UbigeoListByClassAndCodeAndLenCodeQueryRequest, MsgResponse<List<UbigeoListByClassAndCodeAndLenCodeResponseDto>>>
    {
        private readonly IMessageService MessageService;
        private readonly IUbigeoListByClassAndCodeAndLenCodeRepository UbigeoListByClassAndCodeAndLenCodeRepository;
        public UbigeoListByClassAndCodeAndLenCodeQueryHandler(
            IMessageService MessageService,
            IUbigeoListByClassAndCodeAndLenCodeRepository UbigeoListByClassAndCodeAndLenCodeRepository)
        {
            this.UbigeoListByClassAndCodeAndLenCodeRepository = UbigeoListByClassAndCodeAndLenCodeRepository;
            this.MessageService = MessageService;
        }

        public async Task<MsgResponse<List<UbigeoListByClassAndCodeAndLenCodeResponseDto>>> Handle(UbigeoListByClassAndCodeAndLenCodeQueryRequest Request, CancellationToken CancellationToken)
        {
            var MsgResponse = new MsgResponse<List<UbigeoListByClassAndCodeAndLenCodeResponseDto>>();
            MsgResponse.Type = MessageTypeConst.QUERY;
            MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_RESULT);
            MsgResponse.Data = await UbigeoListByClassAndCodeAndLenCodeRepository.ListByClassAndCodeAndLenCodeAsync(Request.UbigeoClass, Request.UbigeoCode, Request.LenUbigeoCode, CancellationToken);
            if (!MsgResponse.Data.Any())
            {
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_EMPTY);
            }
            return MsgResponse;
        }
    }
}
