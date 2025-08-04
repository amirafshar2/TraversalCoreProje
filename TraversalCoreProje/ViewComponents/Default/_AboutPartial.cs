using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _AboutPartial:ViewComponent 
    {
        Aboute2Manager about2Manager = new Aboute2Manager(new EfAbout2DAL());
        public IViewComponentResult Invoke ()
        {
            var q = about2Manager.GetAll().LastOrDefault();
            
            return View(q);
        }
    }
}
