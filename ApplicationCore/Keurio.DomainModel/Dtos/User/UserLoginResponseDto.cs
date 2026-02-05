namespace Keurio.DomainModel.Dtos.User
{
    public record struct UserLoginResponseDto(
         int UserId,
         string UserFirstName,
         string UserLastName,
         string UserEmail,
         int CompanyID,
         string CompanyDocumentNumber,
         string CompanyTradeName,
         string CompanySocialReason,
         short StateID
     );
}
