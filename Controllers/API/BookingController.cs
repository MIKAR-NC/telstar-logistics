using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelstarRoutePlanner.Controllers.API.Request_Models;
using TelstarRoutePlanner.Controllers.API.Response_Models;

namespace TelstarRoutePlanner.Controllers.API
{
    [ApiController]
    //[Authorize]
    public class BookingController : ControllerBase
    {
        [Route("api/booking")]
        public string Book([FromBody] BookRequest bookRequest)
        {
            return new BookResponse(201).Serialize();
        }
    }
}
