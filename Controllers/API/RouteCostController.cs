using Microsoft.AspNetCore.Mvc;
using TelstarRoutePlanner.Controllers.API.Request_Models;
using TelstarRoutePlanner.Controllers.API.Response_Models;
using TelstarRoutePlanner.Data;
using Route = TelstarRoutePlanner.Extensions.RoutePlanner.Route;

namespace TelstarRoutePlanner.Controllers.API
{
    [ApiController]
    public class RouteCostController : ControllerBase
    {
        private Service.Service service { get; set; }
        public RouteCostController(ApplicationDbContext context)
        {
            service = Service.Service.GetInstance(context);
        }

        [Route("api/segments")]
        public string GetCost([FromBody] GetCostRequest getCostRequest)
        {
            Route route = service.GetRoute(getCostRequest.from, getCostRequest.to, getCostRequest.type);
            return new GetCostResponse(route.getTime(), route.getCost(), 200).Serialize();
        }
    }
}
