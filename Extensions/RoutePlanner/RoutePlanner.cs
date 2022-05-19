using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Models;

namespace TelstarRoutePlanner.Extensions.RoutePlanner
{
    public class RoutePlanner
    {
        private List<Route> routes;
        private List<City> onPath;
        private Stack<Segment> currentPath;
        private int numberOfPaths;

        private readonly ApplicationDbContext _context;

        public RoutePlanner(ApplicationDbContext context)
        {
            _context = context;
        }


        // show all simple paths from s to t - use DFS
        public void AllPaths(City from, City to)
        {
            this.routes = new List<List<Segment>>();

            this.onPath = new List<City>();
            this.onPath.Add(from);


            this.currentPath = new Stack<City>();
            this.dfs(from, to);
        }


        private void dfs(City from, City to)
        {
            Segment connectionSegment = _context.GetSegments().Where(segment => segment.City1ID == from.ID || segment.City2ID == to.ID);
            this.currentPath.Push(connectionSegment);

            this.onPath.Add(from);

            if (to.Name == from.Name)
            {
                processCurrentRoute()
                this.numberOfPaths++;
            }
            else // consider all neighbors that would continue path with repeating a node
            {
                var segments = _context.GetSegments().Where(x => x.City1ID == from.ID || x.City2ID == from.ID);

                var adjacentCitites = _context.GetCities().Where(x => segments.Any(y => y.City1ID == x.ID || y.City2ID == x.ID) && x.ID != from.ID);
                foreach (var city in adjacentCitites)
                {
                    if (!onPath.Contains(city))
                    {
                        dfs(from, to);
                    }
                }
            }


        }

        // this implementation just prints the path to standard output
        private void processCurrentRoute()
        {
            Stack<Segment> reverse = new Stack<Segment>();
            foreach (var segment in this.currentPath)
                reverse.push(segment);

            this.routes.add(new Route(reverse.ToList());
        }

        // use DFS
        /*private void dfs(Graph G, int v, int t)
        {

            // add v to current path
            path.push(v);
            onPath[v] = true;

            // found path from s to t
            if (v == t)
            {
                processCurrentPath();
                numberOfPaths++;
            }

            // consider all neighbors that would continue path with repeating a node
            else
            {
                for (int w : G.adj(v))
                {
                    if (!onPath[w])
                        dfs(G, w, t);
                }
            }

            // done exploring from v, so remove from path
            path.pop();
            onPath[v] = false;
        }*/
    }
}


