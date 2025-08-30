using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
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
    public class EfDestinitionDAL : GenericRepository<Destiniton>, IDestinationDAL
    {
        Context db = new Context();
        public List<Destiniton> GetallWhitTourlider()
        {
            return db.destinitons.ToList();
        }
    }
}
