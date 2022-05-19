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

namespace TelstarRoutePlanner.Controllers.API
{
    [ApiController]
    //[Authorize]
    public class RouteController : ControllerBase
    {
        private readonly RoutePlanner _routePlanner;
        private readonly ApplicationDbContext _context;

        public RouteController(ApplicationDbContext context)
        {
            _context = context;
            _routePlanner = new RoutePlanner(_context);
        }

        [Route("api/routes")]
        [HttpGet]
        public IActionResult GetRoutes([FromBody] GetRoutesRequest getRoutesRequest)
        {
            City cityA = _context.GetCities().Where(city => city.Name == getRoutesRequest.from).Single();
            City cityB = _context.GetCities().Where(city => city.Name == getRoutesRequest.to).Single();

            var routes = _routePlanner.AllPaths(cityA, cityB);
            var routesJson = JsonSerializer.Serialize(routes);

            return Ok(routesJson);
        }
    }
}
