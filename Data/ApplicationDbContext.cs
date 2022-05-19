using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TelstarRoutePlanner.Models;

namespace TelstarRoutePlanner.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        private DbSet<City> Cities { get; set; }
        private DbSet<Segment> Segments { get; set; }
        private DbSet<Carrier> Carriers { get; set; }
        private DbSet<Booking> Bookings { get; set; }
        private DbSet<TransportRoute> Routes { get; set; }
        private DbSet<TransportRouteCity> RouteCityAllocations { get; set; }

        public IQueryable<City> GetCities()
        {
            return Cities;  //.Include(x => x.Segments).ThenInclude(x => x.Carrier);
        }

        public IQueryable<Segment> GetSegments()
        {
            return Segments.Include(x => x.City1).Include(x => x.City2).Include(x => x.Carrier);
        }

        public IQueryable<Carrier> GetCarriers()
        {
            return Carriers.Include(x => x.Segments);
        }

        public IQueryable<Booking> GetBookings(string UserID)
        {
            return Bookings.Where(x => x.UserID == UserID).Include(x => x.Route).ThenInclude(x => x.Cities).ThenInclude(x => x.City);
        }

        public bool AddBookingToDb(Booking booking, TransportRoute route, List<City> cities)
        {
            Routes.Add(route);
            RouteCityAllocations.AddRange(cities.Select(x => new TransportRouteCity(route.ID, x.ID, cities.IndexOf(x))));

            booking.RouteID = route.ID;
            Bookings.Add(booking);

            SaveChanges();

            return Bookings.Any(x => x.ID == booking.ID);
        }
    }
}