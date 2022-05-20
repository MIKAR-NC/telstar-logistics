using Route = TelstarRoutePlanner.Extensions.RoutePlanner.Route;

namespace TelstarRoutePlanner.ViewModels
{
    public class RouteTableViewModel
    {
        public string from { get; set; }
        public string to { get; set; }
        public string route { get; set; }
        public string time { get; set; }
        public string cost { get; set; }

        public RouteTableViewModel(Route route)
        {
            from = route.GetCities().FirstOrDefault()?.Name ?? "";
            to = route.GetCities().Last()?.Name ?? "";
            this.route = String.Join(" > ", route.GetCities());
            time = String.Format("{0} hrs", route.TotalTime);
            cost = String.Format("${0}", BookingViewModel.RetCost(route.TotalTime).ToString("#######.##"));
        }
    }
}
