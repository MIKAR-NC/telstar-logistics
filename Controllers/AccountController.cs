using Microsoft.AspNetCore.Mvc;

namespace TelstarRoutePlanner.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
