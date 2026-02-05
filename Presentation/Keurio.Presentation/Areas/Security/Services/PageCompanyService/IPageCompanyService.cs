using Keurio.Presentation.Areas.Security.Models.Page;
using Keurio.Presentation.Areas.Security.Models.PageCompany;
using Keurio.Presentation.Services;

namespace Keurio.Presentation.Areas.Security.Services.PageCompanyService
{
    public interface IPageCompanyService
    {
        Task<ApiResponse<object?>> PageCompanyDeleteCreate(PageCompanyDeleteCreateRequestModel Request);
        Task<ApiResponse<List<PageListResponseModel>>> PageCompanyList(int CompanyID);
    }
}