using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelstarRoutePlanner.Controllers.API.Request_Models;

namespace TelstarRoutePlanner.Controllers.API
{
    [ApiController]
    //[Authorize]
    public class AccountController : ControllerBase
    {
        [Route("api/login")]
        public IActionResult SignIn(SignInRequest signInRequest)
        {
            return Ok(" INTERNAL API test succeeded");
        }
    }
}
