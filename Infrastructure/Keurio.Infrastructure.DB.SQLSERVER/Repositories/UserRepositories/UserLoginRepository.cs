using Keurio.DomainModel.Dtos.User;
using Keurio.DomainService.IRepositories.IUserRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.AppDBContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Keurio.Infrastructure.DB.SQLSERVER.Repositories.UserRepositories
{
    internal class UserLoginRepository(IServiceProvider ServiceProvider) : IUserLoginRepository
    {
        private readonly string ConnectionString = ServiceProvider.GetRequiredService<IOptions<AppDbContext>>().Value.ConnectionSIGCORADB;

        public async Task<UserLoginResponseDto?> GetAsync(UserLoginRequestDto UserCredentials)
        {
            throw new NotImplementedException();
        }
    }
}
