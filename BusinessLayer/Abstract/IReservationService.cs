using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenerik_Service<Reservition>
    {
        public List<Reservition> GetlistByuserid(int userid);
        public List<Reservition> GetlistByuseridcanceld(int userid);
        public List<Reservition> GetlistByuseridaccept(int userid);
    }
}
