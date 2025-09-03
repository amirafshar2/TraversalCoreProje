using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal: IGenerikDAL<Reservition>
    {
        public List<Reservition> GetlistbyUserId(int userId);
        public List<Reservition> Getlistwhitdesetination();
    }
}
