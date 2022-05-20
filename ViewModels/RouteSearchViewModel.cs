using TelstarRoutePlanner.Extensions;
using Route = TelstarRoutePlanner.Extensions.RoutePlanner.Route;

namespace TelstarRoutePlanner.ViewModels
{
    public class RouteSearchViewModel
    {
        public string to { get; set; }
        public string from { get; set; }
        public string cost { get; set; }
        public string time { get; set; }
        public string routeSummary { get; set; }

        public PackageTypeEnum type { get; set; }

        public RouteSearchViewModel()
        {

        }

        public RouteSearchViewModel(Route route)
        {
            from = route.GetCities().FirstOrDefault()?.Name ?? "";
            to = route.GetCities().LastOrDefault()?.Name ?? "";
            routeSummary = String.Join(" > ", route.GetCities().Select(x => x.Name).ToArray());
            cost = String.Format("${0}", (route.TotalTime * 3 / 4));
            time = String.Format("{0}s", route.TotalTime);
        }
    }
}
