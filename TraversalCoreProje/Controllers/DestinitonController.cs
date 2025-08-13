using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class DestinitonController : Controller
    {
        DestinitonsManager manager = new DestinitonsManager(new EfDestinitionDAL());
        public IActionResult Index()
        {
            var q = manager.GetAll();
            return View(q);
               
        }
        [HttpGet]
        public IActionResult Destiniton(int id)
        {
            var q= manager.GetById(id);
            return View(q);
        }
        [HttpPost]
        public IActionResult Destiniton(Destiniton p)
        {
            return View();
        }
    }
}
