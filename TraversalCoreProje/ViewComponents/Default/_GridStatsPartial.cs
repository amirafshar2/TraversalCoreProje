using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _GridStatsPartial : ViewComponent
    {
        #region DI
        private readonly IFeatureServic _Featuremanager;
        public _GridStatsPartial(IFeatureServic featuremanager)
        {
            _Featuremanager = featuremanager;
        }
        #endregion

        #region Invoke
        public IViewComponentResult Invoke()
        {
            
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
        #endregion
    }
}
