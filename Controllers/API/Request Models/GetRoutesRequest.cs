using TelstarRoutePlanner.Controllers.API.Enums;

namespace TelstarRoutePlanner.Controllers.API.Request_Models
{
    public class GetRoutesRequest
    {
        public string from { get; set; }
        public string to { get; set; }

        public GetRoutesRequest(string from, string to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
