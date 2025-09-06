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
    public class UserManager : IUserService
    {
        IUserDAL _userDal;

        public UserManager(IUserDAL userDal)
        {
            _userDal = userDal;
        }

        public void Delete(User entity)
        {
            _userDal.Delete(entity);
        }

        public List<User> GetAll()
        {
            return _userDal.GetList();
        }

        public User GetById(int id)
        {
           return _userDal.Get(id);
        }

        public void Insert(User entity)
        {
            _userDal.Insert(entity);
        }

        public void Update(User entity)
        {
            _userDal.Updater(entity);
        }
    }
}
