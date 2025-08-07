using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult registor()
        {
            return View();
        }
    }
}
