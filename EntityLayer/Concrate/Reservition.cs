using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class Reservition
    {
        public int id { get; set; }
        public string status { get; set; }
        public int HowmanyPapel { get; set; }
        public int Userid { get; set; }
        public string Username { get; set; }
        public int Destintionid { get; set; }
        public DateTime ReservDate { get; set; }
        public DateTime ReservStart  { get; set; }
        public DateTime ReservEnd  { get; set; }
        public int Guidid { get; set; }
    }
}
