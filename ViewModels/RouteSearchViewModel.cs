using TelstarRoutePlanner.Extensions;
using Route = TelstarRoutePlanner.Extensions.RoutePlanner.Route;

namespace TelstarRoutePlanner.ViewModels
{
    public class RouteSearchViewModel
    {
        public string to { get; set; }
        public string from { get; set; }
        public double cost { get; set; }
        public double time { get; set; }
        public PackageTypeEnum type { get; set; }

        public RouteSearchViewModel()
        {

        }

        public RouteSearchViewModel(Route route)
        {
            from = route.GetCities().FirstOrDefault()?.Name ?? "";
            to = route.GetCities().LastOrDefault()?.Name ?? "";
            cost = route.TotalTime * 3 / 4;
            time = route.TotalTime;
        }
    }
}
