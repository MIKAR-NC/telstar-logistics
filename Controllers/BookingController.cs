using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.ComponentModel;
using TelstarRoutePlanner.Data;
using TelstarRoutePlanner.Extensions;
using TelstarRoutePlanner.ViewModels;

namespace TelstarRoutePlanner.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Service.Service service;

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

        [HttpGet]
        public IActionResult GetRoutes(string from, string to, double weight, PackageTypeEnum type)
        {
            if (weight > 40) return BadRequest();

            return Ok(JsonConvert.SerializeObject(service.GetRoutes(from, to).Select(x => new RouteSearchViewModel(x)).ToArray()));
        }
    }
}
