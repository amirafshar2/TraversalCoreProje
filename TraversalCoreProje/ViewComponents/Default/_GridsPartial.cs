using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _GridsPartial : ViewComponent
    {
        #region DI
        private readonly IDestinitionServic _destination;

        public _GridsPartial(IDestinitionServic destination)
        {
            _destination = destination;
        }
        #endregion

        #region Invoke
        public IViewComponentResult Invoke()
        {
            var q = _destination.GetAll();
            return View(q);
        }
        #endregion

    }
}
