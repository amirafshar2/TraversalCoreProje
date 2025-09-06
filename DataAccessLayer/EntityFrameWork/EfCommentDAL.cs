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
    public class EfCommentDAL : GenericRepository<Comment>, ICommentDAL
    {
        Context db = new Context();
        public List<Comment> GetCommentsByDestinationID(int id)
        {
            var q = db.comments.Where(i => i.Destinitonid == id);
            return q.ToList();

        }

        public List<Comment> GetCommentsByUserID(int id)
        {
            var values = db.comments.Where(x => x.Userid == id);
            if (values.Count() != 0)
            {
                return values.ToList();
            }
            return null;
        }
    }
}
