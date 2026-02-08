using Keurio.DomainModel.Dtos;
using Keurio.DomainModel.Dtos.Auth;
using Keurio.Infrastructure.CrossCutting.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keurio.ApplicationService.Commons.Mappers.Auth
{
    public class AuthMapper : IAuthMapper
    {
        public AppUserDto AuthLoginResponseToAppUser(AuthLoginResponseDto AuthLoginResponse)
        {
            AppUserDto AppUser = new AppUserDto()
            {
                UserID = AuthLoginResponse.UserID,
                UserName = AuthLoginResponse.UserName,
                UserFirstName = AuthLoginResponse.UserFirstName,
                UserLastName = AuthLoginResponse.UserLastName,
                UserMail = AuthLoginResponse.UserMail,
                CompanyID = AuthLoginResponse.CompanyID,
                IdiomID = (short)IdiomEnum.Spanish,
                CompanyDocumentNumber = AuthLoginResponse.CompanyDocumentNumber,
                CompanyTradeName = AuthLoginResponse.CompanyTradeName,
                CompanySocialReason = AuthLoginResponse.CompanySocialReason,
                RoleCodes = "1,2"
            };
            return AppUser;
        }
    }
}

