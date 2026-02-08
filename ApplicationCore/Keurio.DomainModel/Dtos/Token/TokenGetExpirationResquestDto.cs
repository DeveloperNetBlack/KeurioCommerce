using System;
using System.Collections.Generic;
using System.Text;

namespace Keurio.DomainModel.Dtos.Token
{
    public record struct TokenGetExpirationResquestDto
    (
        int UserID,
        string TokenRefreshRandom,
        DateTime TokenExpirationDateTime
    );
}
