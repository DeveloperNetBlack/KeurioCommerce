using Keurio.ApplicationService.Features.AuthFeatures.Queries.UserLogin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keurio.Presentation.API.Controllers
{
    public class AuthController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("SignIn")]
        //[SwaggerOperation(Summary = "Iniciar Sesión", Description = "Permite Iniciar Sesión")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(StatusCodeResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn([FromBody] UserLoginQueryRequest query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
