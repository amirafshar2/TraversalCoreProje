using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _AboutPartial:ViewComponent 
    {
        #region DI
        private readonly IAbout2Service _iabout2;

        public _AboutPartial(IAbout2Service iabout2)
        {
            _iabout2 = iabout2;
        }
        #endregion

        #region Invoke 
        public IViewComponentResult Invoke ()
        {
            var q = _iabout2.GetAll().LastOrDefault();
            
            return View(q);
        }
        #endregion
    }
}
