using Keurio.DomainService.IRepositories.IAuthRepositories;
using Keurio.DomainService.IRepositories.ICategoryRepositories;
using Keurio.DomainService.IRepositories.IConstantRepositories;
using Keurio.DomainService.IRepositories.IRolePermissionRepositories;
using Keurio.DomainService.IRepositories.ITokenRepositories;
using Keurio.DomainService.IRepositories.IUbigeoRepositories;
using Keurio.DomainService.Transactions;
using Keurio.Infrastructure.DB.SQLSERVER.AppDBContext;
using Keurio.Infrastructure.DB.SQLSERVER.Repositories.AuthRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.Repositories.CategoryRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.Repositories.ConstantRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.Repositories.RolePermissionRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.Repositories.TokenRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.Repositories.UbigeoRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.Transactions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Keurio.Infrastructure.DB.SQLSERVER
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddKeurioInfrastructureDBSQLSERVER(this IServiceCollection services, IConfiguration configuration, string sectionConnectionName)
        {
            services.Configure<AppDbContext>(configuration.GetSection(sectionConnectionName));
            services.AddScoped<ITransactionAccessor, TransactionAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

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

            services.AddScoped<IRolePermissionListRepository, RolePermissionListRepository>();

            services.AddScoped<IUbigeoListSearchRepository, UbigeoListSearchRepository>();
            services.AddScoped<IUbigeoListByUbigeoClassRepository, UbigeoListByUbigeoClassRepository>();
            services.AddScoped<IUbigeoListByClassAndCodeAndLenCodeRepository, UbigeoListByClassAndCodeAndLenCodeRepository>();

            services.AddScoped<IConstantListRepository, ConstantListRepository>();

            return services;
        }
    }
}
