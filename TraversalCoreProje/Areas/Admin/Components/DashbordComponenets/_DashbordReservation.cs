using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;

namespace TraversalCoreProje.Areas.Admin.Components.DashbordComponenets
{
    public class _DashbordReservation: ViewComponent
    {
        #region DI
        private readonly IReservationService _reservationManager;

        public _DashbordReservation(IReservationService reservationManager)
        {
            _reservationManager = reservationManager;
        }
        #endregion

        #region Invoke
        public IViewComponentResult Invoke()
        {
            var reservation = _reservationManager.GetListWhitDestination().OrderByDescending(x => x.ReservDate).ToList();
            return View(reservation); 
        }
        #endregion
    }
}
