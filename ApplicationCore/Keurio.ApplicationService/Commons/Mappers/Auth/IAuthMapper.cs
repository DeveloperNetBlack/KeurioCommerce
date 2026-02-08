using Keurio.DomainModel.Dtos;
using Keurio.DomainModel.Dtos.Auth;

namespace Keurio.ApplicationService.Commons.Mappers.Auth
{
    public interface IAuthMapper
    {
        AppUserDto AuthLoginResponseToAppUser(AuthLoginResponseDto AuthLoginResponse);
    }
}
