using Keurio.ApplicationService.Commons.Dtos;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.AuthFeatures.Queries.AuthLoginToken
{
    public record struct AuthLoginTokenQueryRequest(
            string CompanyDocumentNumber,
            string UserName,
            string UserPassword
    ) : IRequest<MsgResponse<AuthTokenResponseDto?>>;
}
