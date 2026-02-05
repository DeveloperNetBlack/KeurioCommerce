using Keurio.Presentation.Areas.Security.Models.Constant;
using Keurio.Presentation.Services;

namespace Keurio.Presentation.Areas.Security.Services.ConstantService
{
    public interface IConstantService
    {
        Task<ApiResponse<List<ConstantListResponseModel>>> ConstantList(string ConstantClassConcat);       
    }
}