using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenerik_Service<Comment>
    {
        public List<Comment> GetCommentsByDestinionID(int id);
        public List<Comment> GetCommentsByUserID(int id);
    }
}
