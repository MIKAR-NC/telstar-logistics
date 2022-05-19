using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Models;

namespace TelstarRoutePlanner.Extensions.RoutePlanner
{
    public class Route
    {
        private List<Segment> segments;
        public Route(List<Segment> segments)
        {
            this.segments = segments;
        }
    }
}


