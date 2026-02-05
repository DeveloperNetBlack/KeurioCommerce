using Keurio.DomainModel.Dtos.User;

namespace Keurio.DomainService.IRepositories.IUserRepositories
{
    public interface IUserLoginRepository
    {
        Task<UserLoginResponseDto?> GetAsync(UserLoginRequestDto UserCredentials);
    }
}
