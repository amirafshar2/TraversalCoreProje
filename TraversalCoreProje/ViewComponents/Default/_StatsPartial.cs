using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _StatsPartial : ViewComponent
    {
        #region DI Degisecek
        Context context = new Context();
        #endregion

        #region Invoke
        public IViewComponentResult Invoke ()
        {
            ViewBag.DestinitionsCount = context.destinitons.Count();
            //ViewBag.GuideCount = context.guides.Count();
            ViewBag.Costumer = "285";
            return View();
        }
        #endregion
    }
}
