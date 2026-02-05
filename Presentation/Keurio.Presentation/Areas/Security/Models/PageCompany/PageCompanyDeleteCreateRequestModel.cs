namespace Keurio.Presentation.Areas.Security.Models.PageCompany
{
    public record struct PageCompanyDeleteCreateRequestModel
    (
        int CompanyID,
        List<int> PageIDS
    );
}