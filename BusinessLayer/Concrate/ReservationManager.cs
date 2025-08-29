using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Migrations;
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
            return _Dal.Get(id);
        }

        public List<Reservition> GetlistByuserid(int userid)
        {
            return  _Dal.GetlistbyUserId(userid).Where(x=>x.status == "Ihre Genehmigung ist ausstehend.").ToList();
        }

        public List<Reservition> GetlistByuseridaccept(int userid)
        {
            return _Dal.GetlistbyUserId(userid).Where(x=>x.status == "Die Buchung ist bestätigt.").ToList();
        }

        public List<Reservition> GetlistByuseridcanceld(int userid)
        {           
            return _Dal.GetlistbyUserId(userid).Where(x=> x.status == "Storniert").ToList();
        }

        public void Insert(Reservition entity)
        {
            _Dal.Insert(entity);
        }

        public void Update(Reservition entity)
        {
            _Dal.Updater(entity);
        }
    }
}
