using Microsoft.EntityFrameworkCore;
using CarApplication.Models;

namespace CarApplication.Data
{
    public class CarApplicationContext : DbContext
    {
        public CarApplicationContext(DbContextOptions<CarApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = default!;
        public DbSet<Owner> Owners { get; set; } = default!;
        public DbSet<Service> Services { get; set; } = default!;
        public DbSet<Insurance> Insurances { get; set; } = default!;
    }
}