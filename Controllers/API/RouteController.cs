using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using TelstarRoutePlanner.Controllers.API.Request_Models;
using TelstarRoutePlanner.Controllers.API.Response_Models;
using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Extensions.RoutePlanner;
using TelstarRoutePlanner.Models;
using Route = TelstarRoutePlanner.Extensions.RoutePlanner.Route;

namespace TelstarRoutePlanner.Controllers.API
{
    [ApiController]
    //[Authorize]
    public class RouteController : ControllerBase
    {
        private Service.Service service { get; set; }
        public RouteController(ApplicationDbContext context)
        {
            service = Service.Service.GetInstance(context);
        }

        [Route("api/routes")]
        public string GetRoutes([FromBody]GetRoutesRequest getRoutesRequest)
        {
            List<Route> routes = this.service.GetRoutes(getRoutesRequest.from, getRoutesRequest.to, 0);

            return new GetRoutesResponse(routes).Serialize();
        }

    }
}
