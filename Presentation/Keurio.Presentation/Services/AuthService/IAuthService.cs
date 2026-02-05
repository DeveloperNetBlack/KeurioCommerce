using Keurio.Presentation.Models.Auth;
using Keurio.Presentation.Services;

namespace Keurio.Presentation.Services.AuthService
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthTokenResponseModel?>> SignIn(AuthLoginTokenRequestModel Request);
        Task<ApiResponse<AuthTokenResponseModel?>> Refresh(AuthRefreshTokenRequestModel Request);
    }
}