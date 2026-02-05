using Keurio.DomainModel;
using Keurio.DomainModel.Dtos;

namespace Keurio.DomainService.IServices
{
    public interface IGenerateTokenService
    {
        Task<string> GenerateJWTToken(AppUserDto AppUser);

        Task<ClaimsPrincipalDto?> ValidateJWTToken(string JWTToken, bool IgnoreExpiration = false);

        Task<string> GenerateRandomToken(int ByteLength = 32);
    }
}
