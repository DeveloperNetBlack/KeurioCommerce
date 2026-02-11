using Keurio.DomainModel.Dtos.RolePermission;
using Keurio.DomainService.IRepositories.IRolePermissionRepositories;
using Keurio.Infrastructure.DB.SQLSERVER.AppDBContext;
using Keurio.Infrastructure.DB.SQLSERVER.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Keurio.Infrastructure.DB.SQLSERVER.Repositories.RolePermissionRepositories
{
    internal class RolePermissionListRepository : IRolePermissionListRepository
    {
        private readonly string ConnectionString;
        public RolePermissionListRepository(IOptions<AppDbContext> Options)
        {
            ConnectionString = Options.Value.ConnectionKEURIODB;
        }

        public async Task<List<RolePermissionListResponseDto>> ListAsync(int UserID, int CompanyID, CancellationToken CancellationToken = default)
        {
            var rolePermissionListResponseDtos = new List<RolePermissionListResponseDto>();
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                await Connection.OpenAsync(CancellationToken);
                using (SqlCommand Command = new SqlCommand())
                {
                    Command.CommandText = "Security.spRolePermissionList";
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@UserID", UserID);
                    Command.Parameters.AddWithValue("@CompanyID", CompanyID);
                    Command.Connection = Connection;
                    SqlDataReader DataReader;
                    using (DataReader = await Command.ExecuteReaderAsync(CancellationToken))
                    {
                        if (DataReader.HasRows)
                        {
                            while (await DataReader.ReadAsync(CancellationToken))
                            {
                                var rolePermission = new RolePermissionListResponseDto()
                                {
                                    PageID = Validation.SqlDBToInt32(ref DataReader, "PageID"),
                                    PageParentID = Validation.SqlDBToInt32(ref DataReader, "PageParentID"),
                                    PageHierarchy = Validation.SqlDBToString(ref DataReader, "PageHierarchy"),
                                    PageName = Validation.SqlDBToString(ref DataReader, "PageName"),
                                    PageUrlName = Validation.SqlDBToString(ref DataReader, "PageUrlName"),
                                    PageIconName = Validation.SqlDBToString(ref DataReader, "PageIconName"),
                                    PageOrder = Validation.SqlDBToInt16(ref DataReader, "PageOrder")
                                };
                                rolePermissionListResponseDtos.Add(rolePermission);
                            }
                        }
                    }
                }
            }
            return rolePermissionListResponseDtos;
        }
    }

}
