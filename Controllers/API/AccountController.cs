using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TelstarRoutePlanner.ViewModels;

namespace TelstarRoutePlanner.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        
        public IActionResult Signin(SignInViewModel model)
        {
            return Ok();
        }
    }
}
