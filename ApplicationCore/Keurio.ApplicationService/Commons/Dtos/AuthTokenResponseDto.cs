using System;
using System.Collections.Generic;
using System.Text;

namespace Keurio.ApplicationService.Commons.Dtos
{
    public record struct AuthTokenResponseDto(
       string AccessToken,
       string RefreshToken
    );
}
