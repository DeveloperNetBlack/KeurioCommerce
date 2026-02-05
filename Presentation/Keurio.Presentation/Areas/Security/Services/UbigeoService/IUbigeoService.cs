using Keurio.Presentation.Areas.Security.Models.Ubigeo;
using Keurio.Presentation.Services;

namespace Keurio.Presentation.Areas.Security.Services.UbigeoService
{
    public interface IUbigeoService
    {
        Task<ApiResponse<List<UbigeoListSearchResponsetModel>>> UbigeoListSearch(UbigeoListSearchRequestModel Request);
        Task<ApiResponse<List<UbigeoListByUbigeoClassResponseModel>>> UbigeoListByUbigeoClass(int UbigeoClass);
        Task<ApiResponse<List<UbigeoListByClassAndCodeAndLenCodeResponseModel>>> UbigeoListByClassAndCodeAndLenCode(UbigeoListByClassAndCodeAndLenCodeRequestModel Request);
    }
}