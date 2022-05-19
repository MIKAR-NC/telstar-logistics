using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelstarRoutePlanner.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        [AllowAnonymous]
        public IActionResult GetRoute()
        {
            return Ok("API test succeeded")
        }
    }
}
