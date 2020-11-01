using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<OfficeCar> OfficeCars { get; set; }

        public DbSet<UserDevice> UserDevices { get; set; }
        public DbSet<UserCar> UserCars { get; set; }

        public DbSet<Device> Devices { get; set; }

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserDevice>(e =>
            {
                e.ToView("UserDevices", "dbo");
            });

            builder.Entity<UserCar>(e =>
            {
                e.ToView("UserCars", "dbo");
            });
        }
    }
}
