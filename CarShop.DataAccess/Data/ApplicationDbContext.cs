using CarShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShop.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Car> Cars { get; set; }
        public object Car { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(new Car { Id=1, Model="AudiRS6", MotorFuel="Disel", GearBox="Manual", Colour="red", Mileage=13000, ModelYear=2007, HorsePower=499, Price=599999, Description="fin bil", Path="jucke/jucke"});
            modelBuilder.Entity<Car>().HasData(new Car { Id = 2, Model = "AudiA3", MotorFuel = "Bensin", GearBox = "Automat", Colour = "Blue", Mileage = 20000, ModelYear = 1999, HorsePower = 200, Price = 90000, Description = "fin a3 bil", Path = "jucke/jucke" });
        }

       
    }
}
