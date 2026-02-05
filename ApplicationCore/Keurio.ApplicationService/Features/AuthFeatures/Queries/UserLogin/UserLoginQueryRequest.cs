using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.AuthFeatures.Queries.UserLogin
{
    public record struct UserLoginQueryRequest(string CompanyDocumentNumber, string UserName, string UserPassword) : IRequest<MsgResponse<object>>;
}
