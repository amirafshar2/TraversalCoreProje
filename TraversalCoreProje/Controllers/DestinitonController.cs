using BusinessLayer.Abstract;
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
        #region DI
        private readonly IDestinitionServic _destination;

        public DestinitonController(IDestinitionServic destination)
        {
            _destination = destination;
        }
        #endregion

        #region Index 
        public IActionResult Index()
        {
            var q = _destination.GetAll();
            return View(q);
               
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Destiniton(int id)
        {
            var q= _destination.GetById(id);
            return View(q);
        }
        [HttpPost]
        public IActionResult Destiniton(Destiniton p)
        {
            return View();
        }
        #endregion
    }
}
