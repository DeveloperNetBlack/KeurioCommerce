using Keurio.Presentation.Services;
using Keurio.Presentation.Areas.Security.Models.Ubigeo;
using Keurio.Presentation.Helpers;

namespace Keurio.Presentation.Areas.Security.Services.UbigeoService
{
    public class UbigeoService : IUbigeoService
    {
        private readonly IApiService ApiService;
        private readonly string Controller = "Ubigeo";

        public UbigeoService(IApiServiceFactory ApiServiceFactory)
        {
            this.ApiService = ApiServiceFactory.Create(ConstantsHelper.HttpClientNames.ApiCommerce360);
        }

        public async Task<ApiResponse<List<UbigeoListSearchResponsetModel>>> UbigeoListSearch(UbigeoListSearchRequestModel Request)
        {
            return await ApiService.GetAsync<ApiResponse<List<UbigeoListSearchResponsetModel>>>($"{Controller}/UbigeoListSearch", Request);
        }

        public async Task<ApiResponse<List<UbigeoListByUbigeoClassResponseModel>>> UbigeoListByUbigeoClass(int UbigeoClass)
        {
            return await ApiService.GetAsync<ApiResponse<List<UbigeoListByUbigeoClassResponseModel>>>($"{Controller}/UbigeoListByUbigeoClass/{UbigeoClass}");
        }

        public async Task<ApiResponse<List<UbigeoListByClassAndCodeAndLenCodeResponseModel>>> UbigeoListByClassAndCodeAndLenCode(UbigeoListByClassAndCodeAndLenCodeRequestModel Request)
        {
            return await ApiService.GetAsync<ApiResponse<List<UbigeoListByClassAndCodeAndLenCodeResponseModel>>>($"{Controller}/UbigeoListByClassAndCodeAndLenCode", Request);
        }
    }
}
