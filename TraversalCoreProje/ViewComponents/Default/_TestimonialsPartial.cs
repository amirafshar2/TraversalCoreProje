using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _TestimonialsPartial : ViewComponent
    {
        #region DI
        private readonly ITestimonialServic _testimonial;

        public _TestimonialsPartial(ITestimonialServic testimonial)
        {
            _testimonial = testimonial;
        }
        #endregion

        #region Invoke
        public IViewComponentResult Invoke ()
        {
            var q = _testimonial.GetAll(); ;
            return View(q);
        }
        #endregion
    }
}
