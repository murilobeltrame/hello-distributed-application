using BrewStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BrewStore.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    }
}