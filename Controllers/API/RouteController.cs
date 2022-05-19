using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelstarRoutePlanner.Controllers.API.Request_Models;
using TelstarRoutePlanner.Controllers.API.Response_Models;

namespace TelstarRoutePlanner.Controllers.API
{
    [ApiController]
    //[Authorize]
    public class RouteController : ControllerBase
    {
        [Route("api/routes")]
        public string GetRoutes([FromBody] GetRoutesRequest getRoutesRequest)
        {
            return new GetRoutesResponse(null).Serialize();
        }
    }
}
