using System.Text.Json;
using TelstarRoutePlanner.Models;

namespace TelstarRoutePlanner.Controllers.API.Response_Models
{
    public class GetRoutesResponse : IResponse
    {
        public Extensions.RoutePlanner.Route[]? routes { get; set; }

        public GetRoutesResponse(Route[]? routes)
        {

        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
