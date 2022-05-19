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
    }
}