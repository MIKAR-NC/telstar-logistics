namespace TelstarRoutePlanner.Controllers.API.Request_Models
{
    public class BookRequest
    {
        public string from { get; set; }
        public string to { get; set; }
        public double time { get; set; }
        public double cost { get; set; }

        public BookRequest(string from, string to, double time, double cost)
        {
            this.from = from;
            this.to = to;
            this.time = time;
            this.cost = cost;
        }
    }
}
