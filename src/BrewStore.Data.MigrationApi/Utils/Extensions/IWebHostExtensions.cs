using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BrewStore.Data.MigrationApi.Utils.Extensions
{
    public static class IWebHostExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<ApplicationContext>();

                context.Database.EnsureCreated();

                new Seeder(context).Seed();
            }

            return host;
        }
    }
}
