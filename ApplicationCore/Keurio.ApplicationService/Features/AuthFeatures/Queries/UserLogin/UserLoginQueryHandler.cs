using Keurio.DomainModel.Dtos;
using Keurio.DomainService.IRepositories.IUserRepositories;
using Keurio.DomainService.IServices;
using Keurio.Infrastructure.CrossCutting.Constants;
using Keurio.Infrastructure.CrossCutting.Enums;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using MediatR;
using SIGCora.DomainModel.Dtos.User;
using System.ComponentModel.DataAnnotations;

namespace Keurio.ApplicationService.Features.AuthFeatures.Queries.UserLogin
{
    internal class UserLoginQueryHandler(IUserLoginRepository UserLoginRepository, IMessageService MessageService, IGenerateTokenService GenerateTokenService) : IRequestHandler<UserLoginQueryRequest, MsgResponse<object>>
    {
        public async Task<MsgResponse<object>> Handle(UserLoginQueryRequest request, CancellationToken cancellationToken)
        {
            var UserLoginRequest = new UserLoginRequestDto()
            {
                CompanyDocumentNumber = request.CompanyDocumentNumber,
                UserName = request.UserName,
                UserPassword = request.UserPassword
            };

            var UserLoginResponse = await UserLoginRepository.GetAsync(UserLoginRequest);
            var MsgResponse = new MsgResponse<object>();
            var response = await UserLoginRepository.GetAsync(UserLoginRequest);
            MsgResponse.Type = MessageTypeConst.QUERY;

            if (UserLoginResponse == default)
            {
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.INVALID_CREDENTIAL);
                MsgResponse.Type = MessageTypeConst.ERROR;
            }
            else
            {
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.VALID_CREDENTIAL);

                AppUserDto appUser = new AppUserDto
                {
                    UserID = UserLoginResponse.UserId,
                    UserName = request.UserName,
                    UserFirstName = UserLoginResponse.UserFirstName,
                    UserLastName = UserLoginResponse.UserLastName,
                    UserMail = UserLoginResponse.UserEmail,
                    CompanyID = UserLoginResponse.CompanyID,
                    CompanyDocumentNumber = UserLoginResponse.CompanyDocumentNumber,
                    CompanyTradeName = UserLoginResponse.CompanyTradeName,
                    CompanySocialReason = UserLoginResponse.CompanySocialReason,
                    RoleCodes = "1,2",
                    IdiomID = (short)IdiomEnum.Spanish
                };

                var AccessToken = await GenerateTokenService.GenerateJWTToken(appUser);
                MsgResponse.Data = new
                {
                    AccessToken = AccessToken
                };
            }

            return MsgResponse;
        }

        private List<Commons.UserResponseDto> UserList()
        {
            return new List<Commons.UserResponseDto>
            {
                new Commons.UserResponseDto
                {
                    UserId = 1,
                    CompanyId = 1,
                    CompanyDocumentNumber = "19",
                    UserName = "admin",
                    UserPassword = "admin123"
                },
                new Commons.UserResponseDto
                {
                    UserId = 2,
                    CompanyId = 1,
                    CompanyDocumentNumber = "27",
                    UserName = "user",
                    UserPassword = "user123"
                }
            };
        }
    }
}
