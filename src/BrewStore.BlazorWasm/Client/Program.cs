using System;
using System.Threading.Tasks;
using BrewStore.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrewStore.BlazorWasm.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped<BeverageClient>();
            
            var host = builder.Build();

            Console.WriteLine($"Backend service is: {host.Configuration["SERVICE__BREWSTORE-API__HOST"]}:{host.Configuration["SERVICE__BREWSTORE-API__PORT"]}");

            foreach( var config in host.Configuration.AsEnumerable()) {
                Console.WriteLine($"Config {config.Key} is {config.Value}");
            }

            Console.WriteLine("Done looking for configs ...");


            var beverageClient = host.Services.GetRequiredService<BeverageClient>();

            await host.RunAsync();
        }
    }
}
