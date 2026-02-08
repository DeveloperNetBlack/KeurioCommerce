using System;
using System.Collections.Generic;
using System.Text;

namespace Keurio.DomainModel.Dtos.Token
{
    public record struct TokenGetExpirationResponseDto
    (
        int TokenID,
        int UserID,
        DateTime TokenExpirationDateTime
    );
}
