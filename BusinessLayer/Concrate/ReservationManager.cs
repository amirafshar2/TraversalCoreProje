using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _Dal;

        public ReservationManager(IReservationDal dal)
        {
            _Dal = dal;
        }

        public void Delete(Reservition entity)
        {
            throw new NotImplementedException();
        }

        public List<Reservition> GetAll()
        {
           return _Dal.GetList();
        }

        public Reservition GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservition> GetlistByuserid(int userid)
        {
            return _Dal.GetlistbyUserId(userid);
        }

        public void Insert(Reservition entity)
        {
            _Dal.Insert(entity);
        }

        public void Update(Reservition entity)
        {
            throw new NotImplementedException();
        }
    }
}
