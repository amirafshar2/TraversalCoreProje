using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class User :IdentityUser<int>
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string gender { get; set; }
    }
}
