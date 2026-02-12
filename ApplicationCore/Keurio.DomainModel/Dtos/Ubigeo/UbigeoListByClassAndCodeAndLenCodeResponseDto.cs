namespace Keurio.DomainModel.Dtos.Ubigeo
{
    public record struct UbigeoListByClassAndCodeAndLenCodeResponseDto(
         int UbigeoID,
         string UbigeoCode,
         string UbigeoName
    );
}
