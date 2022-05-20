using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TelstarRoutePlanner.Controllers.API.Request_Models;
using TelstarRoutePlanner.Controllers.API.Response_Models;
using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Extensions.RoutePlanner;
using TelstarRoutePlanner.Models;
using TelstarRoutePlanner.ViewModels;
using Route = TelstarRoutePlanner.Extensions.RoutePlanner.Route;

namespace TelstarRoutePlanner.Controllers.API
{
    [ApiController]
    //[Authorize]
    [AllowAnonymous]
    public class RouteController : ControllerBase
    {
        private Service.Service service { get; set; }
        public RouteController(ApplicationDbContext context)
        {
            service = Service.Service.GetInstance(context);
        }

        [Route("api/routes")]
        public IActionResult GetRoutes([FromBody]GetRoutesRequest getRoutesRequest)
        {
            List<Route> routes = this.service.GetRoutes(getRoutesRequest.from, getRoutesRequest.to);

            return Ok(new GetRoutesResponse(routes).Serialize());
        }

        [Route("api/get-routes")]
        public IActionResult GetRoutes(string from, string to, double weight, string type)
        {
            List<Route> routes = service.GetRoutes(from, to);

            var test = Ok(JsonConvert.SerializeObject(routes.Select(x=> new RouteSearchViewModel(x))));
            return test;
        }

    }
}
