using Keurio.DomainModel.Dtos.Auth;
using Keurio.DomainService.IRepositories.IAuthRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.AppDBContext;
using Keurio.Infrastructure.DB.SQLSERVER.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Data;

namespace Keurio.Infrastructure.DB.SQLSERVER.Repositories.AuthRepositories
{
    internal class AuthLoginRepository(IServiceProvider ServiceProvider) : IAuthLoginRepository
    {
        private readonly string ConnectionString = ServiceProvider.GetRequiredService<IOptions<AppDbContext>>().Value.ConnectionKEURIODB;
       // private readonly string ConnectionDBAccounting360 = ServiceProvider.GetRequiredService<IOptions<AppDbContext>>().Value.ConnectionDBAccounting360;

        public async Task<AuthLoginResponseDto?> LoginAsync(AuthLoginRequestDto UserCredentials, CancellationToken CancellationToken)
        {
            AuthLoginResponseDto? authLoginResponseDto = null;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                using (SqlCommand Command = new SqlCommand())
                {
                    Command.CommandText = "Security.spAuthLogin";
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@CompanyDocumentNumber", UserCredentials.CompanyDocumentNumber);
                    Command.Parameters.AddWithValue("@UserName", UserCredentials.UserName);
                    Command.Parameters.AddWithValue("@UserPassword", UserCredentials.UserPassword);
                    Command.Connection = Connection;
                    SqlDataReader DataReader;
                    using (DataReader = await Command.ExecuteReaderAsync(CancellationToken))
                    {
                        if (DataReader.HasRows)
                        {
                            while (DataReader.Read())
                            {
                                authLoginResponseDto = new AuthLoginResponseDto()
                                {
                                    UserID = Validation.SqlDBToInt32(ref DataReader, "UserID"),
                                    UserName = UserCredentials.UserName,
                                    UserFirstName = Validation.SqlDBToString(ref DataReader, "UserFirstName"),
                                    UserLastName = Validation.SqlDBToString(ref DataReader, "UserLastName"),
                                    UserMail = Validation.SqlDBToString(ref DataReader, "UserMail"),
                                    CompanyID = Validation.SqlDBToInt32(ref DataReader, "CompanyID"),
                                    CompanyDocumentNumber = UserCredentials.CompanyDocumentNumber,
                                    CompanyTradeName = Validation.SqlDBToString(ref DataReader, "CompanyTradeName"),
                                    CompanySocialReason = Validation.SqlDBToString(ref DataReader, "CompanySocialReason"),
                                    StateID = Validation.SqlDBToInt16(ref DataReader, "StateID")
                                };
                            }
                        }
                    }
                }
            }
            return authLoginResponseDto;
        }
    }

}
