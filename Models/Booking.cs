using Microsoft.AspNetCore.Identity;

namespace TelstarRoutePlanner.Models
{
    public class Booking
    {
        public string ID { get; set; }

        public string UserID { get; set; }
        public IdentityUser User { get; set; }

        public string RouteID { get; set; }
        public TransportRoute Route { get; set; }
    }

    public class TransportRoute : Extensions.RoutePlanner.Route
    {
        public string ID { get; set; }
        public double TotalTime { get; set; }
        public double TotalPrice { get; set; }

        public ICollection<TransportRouteCity> Cities { get; set; }
        public TransportRoute(List<City> cities) : base(cities)
        {
            foreach (var city in cities) Cities.Add(new TransportRouteCity(ID, city.ID, cities.IndexOf(city)));
        }
    }

    public class TransportRouteCity
    {
        public string RouteID { get; set; }
        public TransportRoute Route { get; set; }

        public string CityID { get; set; }
        public City City { get; set; }

        public int IndexOnRoute { get; set; }

        public TransportRouteCity(string routeId, string cityId, int idx)
        {
            RouteID = routeId;
            CityID = cityId;
            IndexOnRoute = idx;
        }
    }
}
