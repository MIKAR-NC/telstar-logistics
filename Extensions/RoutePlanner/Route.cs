using Newtonsoft.Json;
using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Models;

namespace TelstarRoutePlanner.Extensions.RoutePlanner
{
    public class Route
    {
        public double TotalTime = 0;

        private List<City>? cities;

        public Route() { }

        public Route(List<City> cities)
        {
            this.cities = cities;
        }

        public Route(List<City> cities, double Time)
        {
            this.cities = cities;
            TotalTime = Time;
        }

        public List<City> GetCities()
        {
            return cities;
        }

        public void setCost(int cost)
        {
            _cost = cost;
        }

        public int getCost()
        {
            return _cost;
        }

        public string Serialize()
        {
            var json = JsonConvert.SerializeObject(this);
            return json;
        }
    }
}


