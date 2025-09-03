using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;

namespace TraversalCoreProje.Areas.Admin.Components.DashbordComponenets
{
    public class _DashbordReservation: ViewComponent
    {
        ReservationManager _reservationManager = new ReservationManager(new EfReservationDAL());
        public IViewComponentResult Invoke()
        {
            var reservation = _reservationManager.GetListWhitDestination().OrderByDescending(x => x.ReservDate).ToList();
            return View(reservation); 
        }
    }
}
