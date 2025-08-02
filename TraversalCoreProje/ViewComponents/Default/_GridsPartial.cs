using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _GridsPartial : ViewComponent
    {
        DestinitonsManager destinitonsManager = new DestinitonsManager(new EfDestinitionDAL());
        public IViewComponentResult Invoke()
        {
            var q = destinitonsManager.GetAll();
            return View(q);
        }
        
    }
}
