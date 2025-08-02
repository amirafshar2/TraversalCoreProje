using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _GridStatsPartial :  ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
