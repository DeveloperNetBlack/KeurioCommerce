using Keurio.ApplicationService.Commons.Dtos;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.AuthFeatures.Commands.AuthRefreshToken
{
    public record struct AuthRefreshTokenCommandRequest
    (string AccessToken,
      string RefreshToken
    ) : IRequest<MsgResponse<AuthTokenResponseDto>>;
}
