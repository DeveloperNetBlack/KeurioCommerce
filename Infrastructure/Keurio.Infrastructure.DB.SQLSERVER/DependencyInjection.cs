using Keurio.DomainService.IRepositories.IAuthRepositories;
using Keurio.DomainService.IRepositories.ICategoryRepositories;
using Keurio.DomainService.IRepositories.ITokenRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.AppDBContext;
using Keurio.Infrastructure.DB.SQLSERVER.Repositories.AuthRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.Repositories.CategoryRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.Repositories.TokenRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Keurio.Infrastructure.DB.SQLSERVER
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddKeurioInfrastructureDBSQLSERVER(this IServiceCollection services, IConfiguration configuration, string sectionConnectionName)
        {
            services.Configure<AppDbContext>(configuration.GetSection(sectionConnectionName));
            //services.AddScoped<ITransactionAccessor, TransactionAccessor>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDependencyInjectionRepository();
            return services;
        }

        private static IServiceCollection AddDependencyInjectionRepository(this IServiceCollection services)
        {
            services.AddScoped<IAuthLoginRepository, AuthLoginRepository>();
            services.AddScoped<IAuthGetRepository, AuthGetRepository>();

            services.AddScoped<ITokenCreateRepository, TokenCreateRepository>();
            services.AddScoped<ITokenGetExpirationRepository, TokenGetExpirationRepository>();
            services.AddScoped<ITokenUpdateRevocationRepository, TokenUpdateRevocationRepository>();

            services.AddScoped<ICategoryChangeStateRepository, CategoryChangeStateRepository>();
            services.AddScoped<ICategoryCreateRepository, CategoryCreateRepository>();
            services.AddScoped<ICategoryGetRepository, CategoryGetRepository>();
            services.AddScoped<ICategoryUpdateRepository, CategoryUpdateRepository>();
            services.AddScoped<ICategoryValidateRepository, CategoryValidateRepository>();

            return services;
        }
    }
}
