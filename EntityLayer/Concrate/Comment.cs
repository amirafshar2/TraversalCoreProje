using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class Comment
    {
        public int id { get; set; }
        public int Userid { get; set; }
        public string CommentUser { get; set; }
        public string CommentContent { get; set; }
        public bool status { get; set; }
        public DateTime CommentData { get; set; }
        public int Destinitonid { get; set; }

    }
}
