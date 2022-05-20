using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using Newtonsoft.Json;
using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Extensions;
using TelstarRoutePlanner.ViewModels;

namespace TelstarRoutePlanner.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Service.Service service { get; set; }
        public BookingController(ApplicationDbContext context)
        {
            _context = context;
            service = Service.Service.GetInstance(context);
        }

        public IActionResult Index()
        {
            ViewBag.Cities = _context.GetCities().Select(x => new SelectListItem(x.Name, x.Name)).ToList();
            ViewBag.ShippingTypes = EnumExtension<PackageTypeEnum>.CastEnumSelectList();

            return View();
        }

        public IActionResult GetRoutes(string from, string to, PackageTypeEnum type, double weight)
        {
            if (weight > 40) return BadRequest();

            return Ok(JsonConvert.SerializeObject(service.GetRoutes(from, to, (int)type).Select(x => new RouteTableViewModel(x)).ToArray()));
        }
    }
}
