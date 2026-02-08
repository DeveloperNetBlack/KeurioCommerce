using Keurio.DomainModel.Dtos.Auth;
using Keurio.DomainService.IRepositories.IAuthRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.AppDBContext;
using Keurio.Infrastructure.DB.SQLSERVER.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Keurio.Infrastructure.DB.SQLSERVER.Repositories.AuthRepositories
{
    internal class AuthGetRepository(IServiceProvider ServiceProvider) : IAuthGetRepository
    {
        private readonly string ConnectionString = ServiceProvider.GetRequiredService<IOptions<AppDbContext>>().Value.ConnectionKEURIODB;

        public async Task<AuthLoginResponseDto?> GetAsync(int UserID, int CompanyID, CancellationToken CancellationToken)
        {
            AuthLoginResponseDto? authLoginResponseDto = null;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                using (SqlCommand Command = new SqlCommand())
                {
                    Command.CommandText = "Security.spAuthGet";
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@UserID", UserID);
                    Command.Parameters.AddWithValue("@CompanyID", CompanyID);
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
                                    UserName = Validation.SqlDBToString(ref DataReader, "UserName"),
                                    UserFirstName = Validation.SqlDBToString(ref DataReader, "UserFirstName"),
                                    UserLastName = Validation.SqlDBToString(ref DataReader, "UserLastName"),
                                    UserMail = Validation.SqlDBToString(ref DataReader, "UserMail"),
                                    CompanyID = Validation.SqlDBToInt32(ref DataReader, "CompanyID"),
                                    CompanyDocumentNumber = Validation.SqlDBToString(ref DataReader, "CompanyDocumentNumber"),
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
