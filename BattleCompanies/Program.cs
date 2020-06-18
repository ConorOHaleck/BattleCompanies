using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleCompanies.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BattleCompanies
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //The Following code replaces CreateHoseBuilder(args).Build().Run();
            //It was replaced in order to use the DBInitializer, which must be done because of critical tables that must be seeded in order for the program to work
            var host = CreateHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<BattleCompanyContext>();
                    DBInitializer.Initialize(context);
                }
                catch(Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the datase.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
