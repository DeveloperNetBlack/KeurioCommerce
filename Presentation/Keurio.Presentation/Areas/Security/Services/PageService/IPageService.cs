using Keurio.Presentation.Areas.Security.Models.Page;
using Keurio.Presentation.Services;

namespace Keurio.Presentation.Areas.Security.Services.PageService
{
    public interface IPageService
    {
        Task<ApiResponse<List<PageListResponseModel>>> PageList();
    }
}
