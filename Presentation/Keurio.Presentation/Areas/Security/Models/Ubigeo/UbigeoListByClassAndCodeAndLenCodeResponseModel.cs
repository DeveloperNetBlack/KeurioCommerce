namespace Keurio.Presentation.Areas.Security.Models.Ubigeo
{
    public record struct UbigeoListByClassAndCodeAndLenCodeResponseModel
    (
         int UbigeoID,
         string UbigeoCode,
         string UbigeoName
    );
}