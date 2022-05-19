using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Models;

namespace TelstarRoutePlanner.Extensions.RoutePlanner
{
    public class Route
    {
        private List<City> cities;
        public Route(List<City> cities)
        {
            this.cities = cities;
        }
    }
}


