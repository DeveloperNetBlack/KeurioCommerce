using Keurio.ApplicationService.Commons.Dtos;
using Keurio.ApplicationService.Features.AuthFeatures.Commands.AuthRefreshToken;
using Keurio.ApplicationService.Features.AuthFeatures.Queries.AuthLoginToken;
using Keurio.Infrastructure.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keurio.Presentation.API.Controllers
{
    public class AuthController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("SignIn")]
        //[SwaggerOperation(Summary = "Inicar sesión", Description = "Permite Inicar sesión.")]
        [ProducesResponseType(typeof(MsgResponse<AuthTokenResponseDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonExceptionResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn([FromBody] AuthLoginTokenQueryRequest Query, CancellationToken CancellationToken)
        {
            return Ok(await Mediator.Send(Query, CancellationToken));
        }

        [AllowAnonymous]
        [HttpPost("Refresh")]
        //[SwaggerOperation(Summary = "Generar JWT", Description = "Permite Generar JWT.")]
        [ProducesResponseType(typeof(MsgResponse<AuthTokenResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonExceptionResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Refresh([FromBody] AuthRefreshTokenCommandRequest Command, CancellationToken CancellationToken)
        {
            return Ok(await Mediator.Send(Command, CancellationToken));
        }
    }
}
