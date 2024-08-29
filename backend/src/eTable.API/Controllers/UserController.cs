using eTable.Application.Services.Interfaces;
using eTable.Communication.Requests;
using eTable.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace eTable.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RegisterUserResponseDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterUser([FromServices] IUserService userService, [FromBody] RegisterUserRequestDTO request)
        {
            var result = await userService.RegisterUser(request);
            return Created(string.Empty, result);
        }
    }
}
