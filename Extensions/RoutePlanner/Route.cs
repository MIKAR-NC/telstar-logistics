using Newtonsoft.Json;
using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Models;

namespace TelstarRoutePlanner.Extensions.RoutePlanner
{
    public class Route
    {
        public int _time = 0;
        public int _cost = 0;
        public List<City> cities;
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


