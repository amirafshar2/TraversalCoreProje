using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class About2
    {
        [Key]
        public int Aboute2ID { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Descriotion { get; set; }
        public string Image { get; set; }

    }
}
