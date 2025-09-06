using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        #region Invoke
        public IViewComponentResult Invoke()
        {
            return View();
        }
        #endregion
    }
}

