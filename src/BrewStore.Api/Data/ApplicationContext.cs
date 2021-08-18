using BrewStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BrewStore.Api.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Beer> Beers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }
    }
}