using X.PagedList;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFrameWork;
using DataAccessLayer.Migrations;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;
using TraversalCoreProje.Areas.Admin.Mthods;
using X.PagedList.Extensions;

namespace TraversalCoreProje.Areas.Admin.Components.DashbordComponenets
{
    public class _DashbordDestinationList : ViewComponent
    {
        DestinitonsManager _bll = new DestinitonsManager(new EfDestinitionDAL());
        DataAccessLayer.Concrate.Context db = new DataAccessLayer.Concrate.Context();
        EntityTauchen _entity = new EntityTauchen();
        public IViewComponentResult Invoke()
        {

            var values = _bll.GetAll().OrderByDescending(x => x.DestinationID);
            List<DestinationModel> dess = new List<DestinationModel>();
            int i = 0;
            foreach (var item in values)
            {
                if (i < 7)
                {
                    var user = db.Users.Find(item.Turlider);
                    DestinationModel qe = _entity.DestinitonToDestinationModel(item);
                    qe.DestinationID = item.DestinationID;
                    qe.username = user.Name;
                    qe.usersurname = user.Surname;
                    qe.userimage = user.Image;
                    qe.DestinationID = item.DestinationID;
                    dess.Add(qe);
                    i++;
                }
                else
                {
                   
                }
            }

            return View(dess);
        }
    }
}
