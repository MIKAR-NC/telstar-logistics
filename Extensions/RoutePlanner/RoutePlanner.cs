using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Models;

namespace TelstarRoutePlanner.Extensions.RoutePlanner
{
    public class RoutePlanner
    {
        private List<Route> routes;
        private List<City> onPath;
        private readonly List<Segment> _segments;
        private readonly List<City> _cities;
        private Stack<City> currentPath;
        private int numberOfPaths;

        private int BAIL_EARLY_VALUE = 10;

        private readonly ApplicationDbContext _context;

        public RoutePlanner(ApplicationDbContext context)
        {
            _context = context;
            _segments = _context.GetSegments().ToList();
            _cities = _context.GetCities().ToList();
        }


        // show all simple paths from s to t - use DFS
        public List<Route> AllPaths(City from, City to)
        {
            this.numberOfPaths = 0;
            this.routes = new List<Route>();

            this.onPath = new List<City>();
            this.onPath.Add(from);


            this.currentPath = new Stack<City>();
            this.dfs(from, to);

            return this.routes;
        }


        private void dfs(City from, City to)
        {
            this.currentPath.Push(from);

            this.onPath.Add(from);

            if (to.Name == from.Name)
            {
                processCurrentRoute();
                this.numberOfPaths++;
            }
            else // consider all neighbors that would continue path with repeating a node
            {
                var segments = _segments.Where(x => x.City1ID == from.ID || x.City2ID == from.ID);

                foreach (var city in _cities)
                {
                    if (!segments.Any(x => city.ID == x.City1ID || city.ID == x.City2ID) || city.ID == from.ID) continue;

                    if (!onPath.Contains(city) && this.numberOfPaths < this.BAIL_EARLY_VALUE)
                    {
                        dfs(city, to);
                    }
                }
            }

            this.currentPath.Pop();
            this.onPath.Remove(from);
        }

        public int getNumberOfPaths()
        {
            return this.numberOfPaths;
        }



        // this implementation just prints the path to standard output
        private void processCurrentRoute()
        {
            Stack<City> reverse = new Stack<City>();
            foreach (var city in this.currentPath)
                reverse.Push(city);

            this.routes.Add(new Route(reverse.ToList()));
        }
    }
}


