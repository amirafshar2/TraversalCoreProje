using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class Guide
    {
        public int GuidID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string  TwiterUrl { get; set; }
        public string InstgramUrl { get; set; }
        public bool Status { get; set; }

    }
}
