using Microsoft.AspNetCore.Mvc;

namespace TelstarRoutePlanner.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
