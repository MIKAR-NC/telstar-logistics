using System.Text.Json;
using Route = TelstarRoutePlanner.Extensions.RoutePlanner.Route;

namespace TelstarRoutePlanner.Controllers.API.Response_Models
{
    public class GetCostResponse : IResponse
    {
        public double time { get; set; }
        public double cost { get; set; }
        public int statusCode { get; set; }
        public GetCostResponse(double time, double cost, int statusCode)
        {
            this.time = time;
            this.cost = cost;
            this.statusCode = statusCode;
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
