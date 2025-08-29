using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    #region create und read
    [Area("Admin")]
    public class DestinationController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DestinationModel p)
        {
            // Logic to save the destination would go here
            ViewBag.message = "Destination added successfully!";
            return View();
        }
    }
    #endregion
}
