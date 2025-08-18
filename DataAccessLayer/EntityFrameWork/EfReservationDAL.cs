using DataAccessLayer.Abstract;
using DataAccessLayer.Migrations;
using DataAccessLayer.Repository;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameWork
{
    public class EfReservationDAL : GenericRepository<Reservition>, IReservationDal
    {
        DataAccessLayer.Concrate.Context db = new DataAccessLayer.Concrate.Context();
        public List<Reservition> GetlistbyUserId(int userId)
        {
            List<Reservition> list = new List<Reservition>();
            var q = db.reservitions.Where(x => x.Userid == userId);
            if (q.Count() > 0)
            {
                foreach (var item in q)
                { list.Add(item); }
            }
            return list;
        }
    }
}
