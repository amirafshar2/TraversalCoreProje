using DataAccessLayer.Abstract;
using DataAccessLayer.Migrations;
using DataAccessLayer.Repository;
using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
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
            
            return db.reservitions.Where(x => x.Userid == userId).Include(y => y.Destiniton).ToList();
        }

        public List<Reservition> Getlistwhitdesetination()
        {
            return db.reservitions.Include(x => x.Destiniton).ToList();
        }
    }
}
