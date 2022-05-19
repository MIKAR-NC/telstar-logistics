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
        private readonly RoutePlanner _routePlanner;
        private readonly ApplicationDbContext _context;
        private readonly List<Segment> _segments;

        public RouteController(ApplicationDbContext context)
        {
            _context = context;
            _routePlanner = new RoutePlanner(_context);
            _segments = _context.GetSegments().ToList();

        }

        [Route("api/routes")]
        [HttpGet]
        public IActionResult GetRoutes([FromBody] GetRoutesRequest getRoutesRequest)
        {
            City cityA = _context.GetCities().Where(city => city.Name == getRoutesRequest.from).Single();
            City cityB = _context.GetCities().Where(city => city.Name == getRoutesRequest.to).Single();

            List<Route> routes = _routePlanner.AllPaths(cityA, cityB);

            // iterate through each segment and get the cost
            // if the we are the provider of the route we get the cost from the database
            // else we ask the other providers for the cost
            foreach(Route route in routes)
            {
                List<City> cities = route.GetCities();

                int totalCost = 0;

                for (int i = 0; i < cities.Count - 1; i++)
                {
                    City city1 = cities[i];
                    City city2 = cities[i + 1];

                    Segment segment = this._segments.FirstOrDefault(s => (s.City1ID == city1.ID && s.City2ID == city2.ID) || (s.City1ID == city2.ID && s.City2ID == city1.ID));

                    if (segment != null)
                    {
                        totalCost += segment.Cost ?? 0;
                    }


                }

                route.setTime(totalCost);
            }


            var routesJson = JsonSerializer.Serialize(routes);

            return Ok(routesJson);
        }
    }
}
