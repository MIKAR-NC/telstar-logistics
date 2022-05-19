using System.Text.Json;

namespace TelstarRoutePlanner.Controllers.API.Response_Models
{
    public class GetCostResponse : Response
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
