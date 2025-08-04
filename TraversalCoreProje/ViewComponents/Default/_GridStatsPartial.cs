using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _GridStatsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FeatureManager _Featuremanager = new FeatureManager(new EfFeatureDAL());
            var q = _Featuremanager.GetAll().Where(q=>q.Status == true);
            var w = q.FirstOrDefault();
            if (w != null)
            {
                ViewBag.fid = w.FeatureId;
                ViewBag.FDescription = w.Description;
                ViewBag.FTitle = w.Title;
                ViewBag.FImage= w.Image;             
            }
            var f = q.Where(f => f.FeatureId != w.FeatureId).ToList();           
            return View(f);
        }
    }
}
