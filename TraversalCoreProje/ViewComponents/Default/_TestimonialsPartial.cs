using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _TestimonialsPartial : ViewComponent
    {
        TestimonialManeger maneger = new TestimonialManeger(new EfTestimonialDAL());

        public IViewComponentResult Invoke ()
        {
            var q = maneger.GetAll(); ;
            return View(q);
        }
    }
}
