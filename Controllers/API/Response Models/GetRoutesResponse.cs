using System.Text.Json;
using TelstarRoutePlanner.Models;

namespace TelstarRoutePlanner.Controllers.API.Response_Models
{
    public class GetRoutesResponse : Response
    {
        public TelstarRoutePlanner.Extensions.RoutePlanner.Route[] routes { get; set; }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
