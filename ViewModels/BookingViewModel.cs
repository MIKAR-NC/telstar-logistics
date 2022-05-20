using TelstarRoutePlanner.Models;
using TelstarRoutePlanner.Services;
using Route = TelstarRoutePlanner.Extensions.RoutePlanner.Route;

namespace TelstarRoutePlanner.ViewModels
{
    public class BookingViewModel
    {
        public string ID { get; set; }
        public double TotalTime { get; set; }
        public double TotalCost { get; set; }
        public List<RouteCityViewModel> routeCities { get; set; }

        public BookingViewModel(Booking item)
        {
            CopyService<Booking, BookingViewModel>.Copy(item, this);
            routeCities = item.Route.Cities.Select(x => new RouteCityViewModel(x.City)).ToList();
        }

        public BookingViewModel(Route item)
        {
            CopyService<Route, BookingViewModel>.Copy(item, this);
            routeCities = item.GetCities().Select(x => new RouteCityViewModel(x)).ToList();
        }
    }

    public class RouteCityViewModel
    {
        public string Name { get; set; }
        public RouteCityViewModel(City city)
        {
            Name = city.Name;
        }
    }
}
