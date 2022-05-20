using System.Text.Json;
using TelstarRoutePlanner.Controllers.API.Enums;
using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Extensions.RoutePlanner;
using TelstarRoutePlanner.Models;
using Route = TelstarRoutePlanner.Extensions.RoutePlanner.Route;

namespace TelstarRoutePlanner.Controllers.Service
{
    public class Service
    {

        private static Service instance;

        public static Service GetInstance(ApplicationDbContext context)
        {
            if (instance == null)
            {
                instance = new Service(context);

            }
            return instance;
        }

        private readonly RoutePlanner _routePlanner;
        private readonly ApplicationDbContext _context;
        private readonly List<Segment> _segments;
        private readonly List<City> _cities;

        private Service(ApplicationDbContext context)
        {
            _context = context;
            _routePlanner = new RoutePlanner(_context);
            _segments = _context.GetSegments().ToList();
            _cities = _context.GetCities().ToList();
        }

        public List<Route> GetRoutes(string from, string to, ParcelType type)
        {
            City cityA = _cities.Where(city => city.Name == from).Single();
            City cityB = _cities.Where(city => city.Name == to).Single();

            List<Route> routes = _routePlanner.AllPaths(cityA, cityB);

            // iterate through each segment and get the cost
            // if the we are the provider of the route we get the cost from the database
            // else we ask the other providers for the cost
            foreach (Route route in routes)
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

                route.TotalTime = totalCost;
            };

            return routes;
        }

        public Route GetRoute(string from, string to, ParcelType type)
        {
            List<Route> routes = GetRoutes(from, to, type);
            Route route = routes.OrderBy(x => x.getTime()).FirstOrDefault();
            return route;
        }
    }
}