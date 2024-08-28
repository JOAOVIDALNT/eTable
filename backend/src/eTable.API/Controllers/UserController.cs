using Microsoft.AspNetCore.Mvc;

namespace eTable.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        
        public async Task<ActionResult> RegisterUser()
        {
            return Ok();
        }
    }
}
