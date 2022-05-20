using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Models;

namespace TelstarRoutePlanner.Extensions.RouteFinder
{
    public class SeedSegments
    {
        private readonly ApplicationDbContext _context;
        private List<City> cities;
        private List<Segment> segments;
        private List<Carrier> carriers;

        public SeedSegments(ApplicationDbContext context)
        {
            _context = context;
            cities = context.GetCities().ToList();
            segments = context.GetSegments().ToList();
            carriers = context.GetCarriers().ToList();
        }

        public void AddSegments()
        {
            if (!SegmentExists("tanger", "marrakesh", CarrierType.Land)) { _context.Add(new Segment(8, GetCityID("tanger"), GetCityID("marrakesh"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("tanger", "sahara", CarrierType.Land)) { _context.Add(new Segment(20, GetCityID("tanger"), GetCityID("sahara"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("tanger", "tunis", CarrierType.Land)) { _context.Add(new Segment(20, GetCityID("tanger"), GetCityID("tunis"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("tanger", "de kanariske oeer", CarrierType.Sea)) { _context.Add(new Segment(null, GetCityID("tanger"), GetCityID("de kanariske oeer"), GetCarrierID(CarrierType.Sea))); }
            if (!SegmentExists("tanger", "tunis", CarrierType.Sea)) { _context.Add(new Segment(null, GetCityID("tanger"), GetCityID("tunis"), GetCarrierID(CarrierType.Sea))); }
            if (!SegmentExists("tanger", "marrakesh", CarrierType.Air)) { _context.Add(new Segment(null, GetCityID("tanger"), GetCityID("marrakesh"), GetCarrierID(CarrierType.Air))); }
            if (!SegmentExists("tanger", "tripoli", CarrierType.Air)) { _context.Add(new Segment(null, GetCityID("tanger"), GetCityID("tripoli"), GetCarrierID(CarrierType.Air))); }

            if (!SegmentExists("de kanariske oeer", "dakar", CarrierType.Sea)) { _context.Add(new Segment(null, GetCityID("de kanariske oeer"), GetCityID("dakar"), GetCarrierID(CarrierType.Sea))); }

            if (!SegmentExists("marrakesh", "dakar", CarrierType.Land)) { _context.Add(new Segment(32, GetCityID("marrakesh"), GetCityID("dakar"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("marrakesh", "sahara", CarrierType.Land)) { _context.Add(new Segment(20, GetCityID("marrakesh"), GetCityID("sahara"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("marrakesh", "sierra leone", CarrierType.Air)) { _context.Add(new Segment(null, GetCityID("marrakesh"), GetCityID("sierra leone"), GetCarrierID(CarrierType.Air))); }
            if (!SegmentExists("marrakesh", "guldkysten", CarrierType.Air)) { _context.Add(new Segment(null, GetCityID("marrakesh"), GetCityID("guldkysten"), GetCarrierID(CarrierType.Air))); }

            if (!SegmentExists("sahara", "darfur", CarrierType.Land)) { _context.Add(new Segment(32, GetCityID("sahara"), GetCityID("darfur"), GetCarrierID(CarrierType.Land))); }

            if (!SegmentExists("tunis", "tripoli", CarrierType.Land)) { _context.Add(new Segment(12, GetCityID("tunis"), GetCityID("tripoli"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("tunis", "cairo", CarrierType.Sea)) { _context.Add(new Segment(null, GetCityID("tunis"), GetCityID("cairo"), GetCarrierID(CarrierType.Sea))); }

            if (!SegmentExists("tripoli", "omdurman", CarrierType.Land)) { _context.Add(new Segment(24, GetCityID("tripoli"), GetCityID("omdurman"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("tripoli", "guldkysten", CarrierType.Air)) { _context.Add(new Segment(null, GetCityID("tripoli"), GetCityID("guldkysten"), GetCarrierID(CarrierType.Air))); }
            if (!SegmentExists("tripoli", "darfur", CarrierType.Air)) { _context.Add(new Segment(null, GetCityID("tripoli"), GetCityID("darfur"), GetCarrierID(CarrierType.Air))); }

            if (!SegmentExists("cairo", "omdurman", CarrierType.Land)) { _context.Add(new Segment(16, GetCityID("cairo"), GetCityID("omdurman"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("cairo", "suakin", CarrierType.Air)) { _context.Add(new Segment(null, GetCityID("cairo"), GetCityID("suakin"), GetCarrierID(CarrierType.Sea))); }
            if (!SegmentExists("cairo", "suakin", CarrierType.Air)) { _context.Add(new Segment(null, GetCityID("cairo"), GetCityID("suakin"), GetCarrierID(CarrierType.Air))); }

            if (!SegmentExists("omdurman", "darfur", CarrierType.Land)) { _context.Add(new Segment(12, GetCityID("omdurman"), GetCityID("darfur"), GetCarrierID(CarrierType.Land))); }

            if (!SegmentExists("suakin", "darfur", CarrierType.Land)) { _context.Add(new Segment(16, GetCityID("suakin"), GetCityID("darfur"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("suakin", "adis abeba", CarrierType.Land)) { _context.Add(new Segment(12, GetCityID("suakin"), GetCityID("adis abeba"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("suakin", "kap guardafui", CarrierType.Sea)) { _context.Add(new Segment(null, GetCityID("suakin"), GetCityID("kap guardafui"), GetCarrierID(CarrierType.Sea))); }
            if (!SegmentExists("suakin", "darfur", CarrierType.Air)) { _context.Add(new Segment(null, GetCityID("suakin"), GetCityID("darfur"), GetCarrierID(CarrierType.Air))); }
            if (!SegmentExists("suakin", "victoriasoeen", CarrierType.Air)) { _context.Add(new Segment(null, GetCityID("suakin"), GetCityID("victoriasoeen"), GetCarrierID(CarrierType.Air))); }

            if (!SegmentExists("darfur", "wadai", CarrierType.Land, 16)) { _context.Add(new Segment(16, GetCityID("darfur"), GetCityID("wadai"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("darfur", "wadai", CarrierType.Land, 32)) { _context.Add(new Segment(32, GetCityID("darfur"), GetCityID("wadai"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("darfur", "slavekysten", CarrierType.Land)) { _context.Add(new Segment(28, GetCityID("darfur"), GetCityID("slavekysten"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("darfur", "congo", CarrierType.Land)) { _context.Add(new Segment(24, GetCityID("darfur"), GetCityID("congo"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("darfur", "bahrel ghazal", CarrierType.Land)) { _context.Add(new Segment(8, GetCityID("darfur"), GetCityID("bahrel ghazal"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("darfur", "kabalo", CarrierType.Air)) { _context.Add(new Segment(null, GetCityID("darfur"), GetCityID("kabalo"), GetCarrierID(CarrierType.Air))); }

            if (!SegmentExists("wadai", "slavekysten", CarrierType.Land)) { _context.Add(new Segment(28, GetCityID("wadai"), GetCityID("slavekysten"), GetCarrierID(CarrierType.Land))); }
            if (!SegmentExists("wadai", "congo", CarrierType.Land)) { _context.Add(new Segment(24, GetCityID("wadai"), GetCityID("congo"), GetCarrierID(CarrierType.Land))); }




            _context.SaveChanges();


        }

        public string GetCityID(string name)
        {
            return _context.GetCities().SingleOrDefault(x => x.Name == name).ID;
        }

        public bool SegmentExists(string cityAName, string cityBName, CarrierType carrier, int? cost = null)
        {
            return _context.GetSegments().Any(x => ((x.City1.Name == cityAName && x.City2.Name == cityBName) || (x.City1.Name == cityBName && x.City2.Name == cityAName)) && x.Carrier.Type == carrier && (cost == null ? 1 == 1 : x.Cost == cost));
        }

        public string GetCarrierID(CarrierType type)
        {
            return _context.GetCarriers().SingleOrDefault(x => x.Type == type)?.ID;
        }
    }
}
