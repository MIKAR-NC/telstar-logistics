using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Extensions;

namespace TelstarRoutePlanner.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Cities = _context.GetCities().Select(x => new SelectListItem(x.Name, x.ID)).ToList();
            ViewBag.ShippingTypes = Enum.GetValues(typeof(PackageTypeEnum)).Cast<PackageTypeEnum>()
                .Select(x => 
                    new SelectListItem((x.GetType().GetField(x.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[])?
                        .First().Description, ((int)x).ToString()));
            
            return View();
        }
    }
}
