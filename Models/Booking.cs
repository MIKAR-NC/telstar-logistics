using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelstarRoutePlanner.Extensions;
using Route = TelstarRoutePlanner.Extensions.RoutePlanner.Route;

namespace TelstarRoutePlanner.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        public string UserID { get; set; }
        public IdentityUser User { get; set; }

        public string RouteID { get; set; }
        public TransportRoute Route { get; set; }

        public PackageTypeEnum Type { get; set; }
    }

    public class TransportRoute : Route
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public double TotalCost { get; set; }

        public ICollection<TransportRouteCity> Cities { get; set; }
        public TransportRoute(List<City> cities, double time) : base(cities, time)
        {
            Cities = cities.Select(x => new TransportRouteCity(ID, x.ID, cities.IndexOf(x))).ToList();
            TotalCost = 3 * (time / 4);
        }

        public TransportRoute(List<City> cities) : base(cities)
        {
            Cities = cities.Select(x => new TransportRouteCity(ID, x.ID, cities.IndexOf(x))).ToList();
        }

        public TransportRoute() : base() { }
    }

    public class TransportRouteCity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        public string RouteID { get; set; }
        public TransportRoute Route { get; set; }

        public string CityID { get; set; }
        public City City { get; set; }

        public int IndexOnRoute { get; set; }

        public TransportRouteCity() { }

        public TransportRouteCity(string routeId, string cityId, int idx)
        {
            RouteID = routeId;
            CityID = cityId;
            IndexOnRoute = idx;
        }
    }
}
