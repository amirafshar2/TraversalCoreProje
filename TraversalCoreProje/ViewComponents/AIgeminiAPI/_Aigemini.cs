using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using TraversalCoreProje.Models.PicMethods.AI;

namespace TraversalCoreProje.ViewComponents.AIgeminiAPI
{
    public class _Aigemini : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ChatViewModel model)
        {
            return View(model);
        }
    }
}