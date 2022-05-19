using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Models;

namespace TelstarRoutePlanner.Extensions.RoutePlanner
{
    public class Route
    {
        private int _time = 0;
        private List<City> cities;
        public Route(List<City> cities)
        {
            this.cities = cities;
        }

        public List<City> GetCities()
        {
            return cities;
        }

        public void setTime(int time)
        {
            _time = time;
        }

        public int getTime()
        {
            return _time;
        }
    }
}


