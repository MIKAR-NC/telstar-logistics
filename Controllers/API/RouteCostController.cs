using Microsoft.AspNetCore.Mvc;
using TelstarRoutePlanner.Controllers.API.Request_Models;
using TelstarRoutePlanner.Controllers.API.Response_Models;

namespace TelstarRoutePlanner.Controllers.API
{
    [ApiController]
    public class RouteCostController : ControllerBase
    {
        [Route("api/segments")]
        public string GetCost([FromBody] GetCostRequest getCostRequest)
        {
            return new GetCostResponse(9.2, 8, 200).Serialize();
        }
    }
}
