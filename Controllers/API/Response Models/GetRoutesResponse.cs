using System.Text.Json;
using TelstarRoutePlanner.Models;

namespace TelstarRoutePlanner.Controllers.API.Response_Models
{
    public class GetRoutesResponse : IResponse
    {
<<<<<<< HEAD
        public Extensions.RoutePlanner.Route[]? routes { get; set; }

        public GetRoutesResponse(Route[]? routes)
        {

        }
=======
        public List<TelstarRoutePlanner.Extensions.RoutePlanner.Route> Routes { get; set; }
>>>>>>> origin/Development

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
