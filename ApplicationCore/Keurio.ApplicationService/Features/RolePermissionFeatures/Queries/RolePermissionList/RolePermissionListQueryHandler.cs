using Keurio.DomainModel.Dtos.RolePermission;
using Keurio.DomainService.IRepositories.IRolePermissionRepositories;
using Keurio.DomainService.IServices;
using Keurio.Infrastructure.CrossCutting.Constants;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.RolePermissionFeatures.Queries.RolePermissionList
{
    internal class RolePermissionListQueryHandler : IRequestHandler<RolePermissionListQueryRequest, MsgResponse<List<RolePermissionListResponseDto>>>
    {
        private readonly IRolePermissionListRepository RolePermissionListRepository;
        private readonly IMessageService MessageService;

        public RolePermissionListQueryHandler(IRolePermissionListRepository RolePermissionListRepository,
            ICurrentSessionService CurrentSessionService,
            IMessageService MessageService
            )
        {
            this.RolePermissionListRepository = RolePermissionListRepository;
            this.MessageService = MessageService;
        }

        public async Task<MsgResponse<List<RolePermissionListResponseDto>>> Handle(RolePermissionListQueryRequest Request, CancellationToken CancellationToken)
        {
            var MsgResponse = new MsgResponse<List<RolePermissionListResponseDto>>();

            MsgResponse.Type = MessageTypeConst.QUERY;
            MsgResponse.Data = await RolePermissionListRepository.ListAsync(Request.UserID, Request.CompanyID, CancellationToken);
            
            if (MsgResponse.Data is null)
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_EMPTY);
            else 
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_RESULT);
            
            return MsgResponse;
        }
    }
}
