using Keurio.DomainModel.Dtos.Ubigeo;
using Keurio.DomainService.IRepositories.IUbigeoRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.AppDBContext;
using Keurio.Infrastructure.DB.SQLSERVER.Extensions;
using Keurio.Infrastructure.DB.SQLSERVER.Transactions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Keurio.Infrastructure.DB.SQLSERVER.Repositories.UbigeoRepositories
{
    internal class UbigeoListByClassAndCodeAndLenCodeRepository : IUbigeoListByClassAndCodeAndLenCodeRepository
    {

        private readonly string ConnectionString;
        private readonly ITransactionAccessor TransactionAccessor;
        public UbigeoListByClassAndCodeAndLenCodeRepository(IOptions<AppDbContext> Options,
              ITransactionAccessor TransactionAccessor)
        {
            ConnectionString = Options.Value.ConnectionKEURIODB;
            this.TransactionAccessor = TransactionAccessor;
        }

        public async Task<List<UbigeoListByClassAndCodeAndLenCodeResponseDto>> ListByClassAndCodeAndLenCodeAsync(int UbigeoClass, string UbigeoCode, int LenUbigeoCode, CancellationToken CancellationToken = default)
        {
            var listadoUbigeo = new List<UbigeoListByClassAndCodeAndLenCodeResponseDto>();
            var Connection = await TransactionAccessor.GetOrOpenConnectionAsync(ConnectionString, CancellationToken);
            using (SqlCommand Command = new SqlCommand())
            {
                Command.CommandText = "Security.spUbigeoListByClassAndCodeAndLenCode";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@UbigeoClass", UbigeoClass);
                Command.Parameters.AddWithValue("@UbigeoCode", UbigeoCode ?? "");
                Command.Parameters.AddWithValue("@LenUbigeoCode", LenUbigeoCode);
                Command.Connection = Connection;
                SqlDataReader DataReader;
                using (DataReader = await Command.ExecuteReaderAsync(CancellationToken))
                {
                    if (DataReader.HasRows)
                    {
                        while (await DataReader.ReadAsync(CancellationToken))
                        {
                            var listado = new UbigeoListByClassAndCodeAndLenCodeResponseDto()
                            {
                                UbigeoID = Validation.SqlDBToInt32(ref DataReader, "UbigeoID"),
                                UbigeoCode = Validation.SqlDBToString(ref DataReader, "UbigeoCode"),
                                UbigeoName = Validation.SqlDBToString(ref DataReader, "UbigeoName"),
                            };
                            listadoUbigeo.Add(listado);
                        }
                    }
                }
            }
            return listadoUbigeo;
        }
    }
}
