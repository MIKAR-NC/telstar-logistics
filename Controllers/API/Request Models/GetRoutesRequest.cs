using System.ComponentModel.DataAnnotations;
using TelstarRoutePlanner.Controllers.API.Enums;

namespace TelstarRoutePlanner.Controllers.API.Request_Models
{
    public class GetRoutesRequest
    {
        public string from { get; set; }
        public string to { get; set; }
        public ParcelType type { get; set; }
        public double weight { get; set; }

        public GetRoutesRequest(string from, string to, ParcelType type, double weight)
        {
            this.from = from;
            this.to = to;
            this.type = type;
            this.weight = weight;

            Validate();
        }

        public void Validate()
        {
            RequestValidator.ValidateFrom(from);
            RequestValidator.ValidateTo(to);
            RequestValidator.ValidateType(type);
            RequestValidator.ValidateWeight(weight);
        }
    }
}
