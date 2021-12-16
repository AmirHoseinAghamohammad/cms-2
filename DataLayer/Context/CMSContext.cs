using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer
{
   public class CMSContext:DbContext
    {
        public DbSet<BlogGroup> BlogGroups { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Slider> Sliders{ get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<AdminLogin> AdminLogins{ get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Footer> Footers{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BlogCommentConfig());
            modelBuilder.Configurations.Add(new BlogConfig());
        }
    }
}
