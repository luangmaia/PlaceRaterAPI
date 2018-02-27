using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI
{
    public class PlaceRaterContext : DbContext
    {
        public PlaceRaterContext(): base("name=PlaceRaterDBConnectionString")
        {
            Database.SetInitializer(new PlaceRaterDBInitializer());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
