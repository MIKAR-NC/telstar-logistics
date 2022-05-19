using System.Text.Json;

namespace TelstarRoutePlanner.Controllers.API.Response_Models
{
    public class BookResponse : IResponse
    {
        public int statusCode { get; set; }
        public BookResponse(int statusCode)
        {
            this.statusCode = statusCode;
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
