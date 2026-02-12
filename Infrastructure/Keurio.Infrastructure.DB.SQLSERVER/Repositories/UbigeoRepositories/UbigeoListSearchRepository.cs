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
    internal class UbigeoListSearchRepository : IUbigeoListSearchRepository
    {
        private readonly string ConnectionString;
        private readonly ITransactionAccessor TransactionAccessor;
        public UbigeoListSearchRepository(IOptions<AppDbContext> Options,
              ITransactionAccessor TransactionAccessor)
        {
            ConnectionString = Options.Value.ConnectionKEURIODB;
            this.TransactionAccessor = TransactionAccessor;
        }

        public async Task<List<UbigeoListSearchResponseDto>> ListSearchAsync(int UbigeoClassContinent, string UbigeoName, CancellationToken CancellationToken = default)
        {
            var listadoUbigeo = new List<UbigeoListSearchResponseDto>();
            var Connection = await TransactionAccessor.GetOrOpenConnectionAsync(ConnectionString, CancellationToken);
            using (SqlCommand Command = new SqlCommand())
            {
                Command.CommandText = "Security.spUbigeoListSearch";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@UbigeoClassContinent", UbigeoClassContinent);
                Command.Parameters.AddWithValue("@UbigeoName", UbigeoName ?? "");
                Command.Connection = Connection;
                SqlDataReader DataReader;
                using (DataReader = await Command.ExecuteReaderAsync(CancellationToken))
                {
                    if (DataReader.HasRows)
                    {
                        while (await DataReader.ReadAsync(CancellationToken))
                        {
                            var listado = new UbigeoListSearchResponseDto()
                            {

                                DepartmentName = Validation.SqlDBToString(ref DataReader, "DepartmentName"),
                                ProvinceName = Validation.SqlDBToString(ref DataReader, "ProvinceName"),
                                DistrictID = Validation.SqlDBToInt32(ref DataReader, "DistrictID"),
                                DistrictCode = Validation.SqlDBToString(ref DataReader, "DistrictCode"),
                                DistrictName = Validation.SqlDBToString(ref DataReader, "DistrictName"),
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
