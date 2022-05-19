using System.Text.Json;
using TelstarRoutePlanner.Models;

namespace TelstarRoutePlanner.Controllers.API.Response_Models
{
    public class GetRoutesResponse : Response
    {
        public List<TelstarRoutePlanner.Extensions.RoutePlanner.Route> Routes { get; set; }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
