using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _AIpartial : ViewComponent
    {
        #region Invoke
        public IViewComponentResult Invoke()
        {
            return View();

        }
        #endregion
    }
}
