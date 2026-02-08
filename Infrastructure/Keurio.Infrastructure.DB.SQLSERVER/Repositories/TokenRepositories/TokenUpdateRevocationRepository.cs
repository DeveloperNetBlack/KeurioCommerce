using Keurio.DomainModel.Model;
using Keurio.DomainService.IRepositories.ITokenRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.AppDBContext;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Data;

namespace Keurio.Infrastructure.DB.SQLSERVER.Repositories.TokenRepositories
{
    internal class TokenUpdateRevocationRepository(IServiceProvider ServiceProvider) : ITokenUpdateRevocationRepository
    {
        private readonly string ConnectionString = ServiceProvider.GetRequiredService<IOptions<AppDbContext>>().Value.ConnectionKEURIODB;

        public async Task<int> UpdateRevocationAsync(Token Model, CancellationToken CancellationToken)
        {
            int RecordAffected = 0;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                using (SqlCommand Command = new SqlCommand())
                {
                    Command.CommandText = "Security.uspTokenUpdateRevocation";
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@TokenID", Model.TokenID);
                    Command.Parameters.AddWithValue("@TokenRevocationDateTime", Model.TokenCreateDateTime);
                    Command.Connection = Connection;
                    RecordAffected = await Command.ExecuteNonQueryAsync(CancellationToken);
                }
            }
            return RecordAffected;
        }
    }
}
