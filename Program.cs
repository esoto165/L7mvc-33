//tinfo200:[2021-03-03-sotoe-dykstra1] - Added using statements to the configuration services that allows the creation of a new database
// if one is not found and is loaded with test data from DbInitializer class for dependency injection
using ContosoUniversity.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //tinfo200:[2021-03-03-sotoe-dykstra1] - separated fluent API to inject method calls if database exists or not
            var host = CreateHostBuilder(args).Build();

            //tinfo200:[2021-03-11-sotoe-dykstra1] - Using the dependency injection container, assigning a variable
            // for a database context instance. If a database is not found, or at this point if found, then DbInitializer class is called to create a seed database
            // with test data otherwise if DbInitializer fails then notify the end-user
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        //tinfo200:[2021-03-03-sotoe-dykstra1] - CreateDbIfNotExists method is made to create a database if one is not found; however,
        // is not called at this point of editing and is likely for continued database integrity for ongoing CRUD operations later in the tutorial
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        //tinfo200:[2021-03-03-sotoe-dykstra1] - creates and configures the web builder object
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
