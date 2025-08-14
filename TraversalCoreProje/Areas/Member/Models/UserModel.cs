using System.Reflection.Metadata.Ecma335;

namespace TraversalCoreProje.Areas.Member.Models
{
    public class UserModel
    {
        public string name { get; set; }
        public string surename { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public string image { get; set; }
        public string password { get; set; }
        public string passwordcurrent { get; set; }
        public string passwordconfirm { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
