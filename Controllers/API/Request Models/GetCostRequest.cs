using TelstarRoutePlanner.Controllers.API.Enums;

namespace TelstarRoutePlanner.Controllers.API.Request_Models
{
    public class GetCostRequest
    {
        public string from { get; set; }
        public string to { get; set; }
        public ParcelType type { get; set; }
        public double weight { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double length { get; set; }

        public GetCostRequest(string from, string to, ParcelType type, double weight, double width, double height, double length)
        {
            this.from = from;
            this.to = to;
            this.type = type;
            this.weight = weight;
            this.width = width;
            this.height = height;
            this.length = length;

            Validate();
        }

        public void Validate()
        {
            RequestValidator.ValidateFrom(from);
            RequestValidator.ValidateTo(to);
            RequestValidator.ValidateWeight(weight);
        }
    }
}