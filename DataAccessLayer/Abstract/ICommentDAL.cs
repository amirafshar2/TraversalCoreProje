using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDAL : IGenerikDAL<Comment>
    {
        public List<Comment> GetCommentsByDestinationID(int id);
    }
}
