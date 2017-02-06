using Model;
using System.Data.Entity;

namespace Migration
{
    public class WebProjectRESTFullTemplate : DbContext
    {
        public WebProjectRESTFullTemplate() : base("WebProjectRESTFullTemplate") //Defines the database name
        {
            Database.SetInitializer<WebProjectRESTFullTemplate>(null);
        }

        public DbSet<Car> Car { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().ToTable("Cars");
        }
    }
}
