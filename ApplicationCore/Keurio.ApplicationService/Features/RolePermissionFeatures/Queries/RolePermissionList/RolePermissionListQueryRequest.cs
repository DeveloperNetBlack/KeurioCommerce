using Keurio.DomainModel.Dtos.RolePermission;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keurio.ApplicationService.Features.RolePermissionFeatures.Queries.RolePermissionList
{
    public record struct RolePermissionListQueryRequest
    (
     int UserID,
     int CompanyID
    ) : IRequest<MsgResponse<List<RolePermissionListResponseDto>>>;
}
