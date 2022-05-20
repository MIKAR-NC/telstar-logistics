using Newtonsoft.Json;
using TelstarRoutePlanner.Models;
using Route = TelstarRoutePlanner.Extensions.RoutePlanner.Route;

namespace TelstarRoutePlanner.Controllers.API.Response_Models
{
    public class GetRoutesResponse : IResponse
    {
        public Route[]? routes { get; set; }

        public GetRoutesResponse(List<Route> routes)
        {
            this.routes = routes.ToArray();
        }

        public string Serialize()
        {
            var json = JsonConvert.SerializeObject(this.routes);
            return json;
        }
    }
}
