using Keurio.ApplicationService.Commons.Dtos;
using Keurio.ApplicationService.Commons.Mappers.Auth;
using Keurio.DomainModel.Dtos;
using Keurio.DomainModel.Dtos.Auth;
using Keurio.DomainModel.Model;
using Keurio.DomainService.IRepositories.IAuthRepositories;
using Keurio.DomainService.IRepositories.ITokenRepositories;
using Keurio.DomainService.IServices;
using Keurio.Infrastructure.CrossCutting.Constants;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace Keurio.ApplicationService.Features.AuthFeatures.Queries.AuthLoginToken
{
    internal class AuthLoginTokenQueryHandler(
             IAuthLoginRepository AuthLoginRepository,
             IGenerateTokenService GenerateTokenService,
             ITokenCreateRepository TokenCreateRepository,
             IAuthMapper AuthMapper
        ) : IRequestHandler<AuthLoginTokenQueryRequest, MsgResponse<AuthTokenResponseDto?>>
    {
        public async Task<MsgResponse<AuthTokenResponseDto?>> Handle(AuthLoginTokenQueryRequest Request, CancellationToken CancellationToken)
        {
            var UserLoginRequest = new AuthLoginRequestDto()
            {
                CompanyDocumentNumber = Request.CompanyDocumentNumber,
                UserName = Request.UserName,
                UserPassword = Request.UserPassword
            };

            var AuthLoginResponse = await AuthLoginRepository.LoginAsync(UserLoginRequest, CancellationToken);

            var MsgResponse = new MsgResponse<AuthTokenResponseDto?>();
            MsgResponse.Type = MessageTypeConst.QUERY;

            if (AuthLoginResponse == null)
            {
                MsgResponse.Message = MessageDescriptionConst.INVALID_CREDENTIAL_DESCRIPTION;
            }
            else
            {
                MsgResponse.Message = MessageDescriptionConst.VALID_CREDENTIAL_DESCRIPTION;
                AppUserDto AppUser = AuthMapper.AuthLoginResponseToAppUser(AuthLoginResponse.Value);
                var AuthTokenResponse = new AuthTokenResponseDto()
                {
                    AccessToken = await GenerateTokenService.GenerateJWTToken(AppUser),
                    RefreshToken = await GenerateTokenService.GenerateRandomToken()
                };
                var Model = new Token()
                {
                    UserID = AppUser.UserID,
                    CompanyID = AppUser.CompanyID,
                    TokenRefreshRandom = AuthTokenResponse.RefreshToken,
                    TokenCreateDateTime = AppUser.CurrentDateTime,
                    TokenExpirationRandomDateTime = AppUser.ExpirationRandomDateTime,
                    TokenExpirationJWTDateTime = AppUser.ExpirationJWTDateTime
                };

                await TokenCreateRepository.CreateAsync(Model, CancellationToken);

                MsgResponse.Data = AuthTokenResponse;
            }
            return MsgResponse;
        }
    }

}
