using Microsoft.AspNetCore.Mvc;

namespace Smkas.Web.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        public IActionResult Index => View();
    }
}
