using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelstarRoutePlanner.Controllers.API
{
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        [Route("api/booking")]
        public IActionResult Book()
        {
            return Ok(" INTERNAL API test succeeded");
        }
    }
}
