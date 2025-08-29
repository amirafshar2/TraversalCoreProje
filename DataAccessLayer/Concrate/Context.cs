using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate
{
    public class Context :IdentityDbContext<User,Roll,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=TraversalDB;Integrated Security=True;");
        }
        public DbSet<About> abouts { get; set; }
        public DbSet<About2> abouts2 { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Destiniton> destinitons { get; set; }
        public DbSet<Feature> features { get; set; }
        public DbSet<Feature2> features2 { get; set; }
        public DbSet<Guide> guides { get; set; }
        public DbSet<Newsletter> newsletters { get; set; }
        public DbSet<SubAbout> subabouts { get; set; }
        public DbSet<Testimonial> testsimonials { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Reservition> reservitions { get; set;}
    }
}
