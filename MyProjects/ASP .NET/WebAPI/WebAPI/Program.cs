using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DbContexts;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run(); Reason for commenting below.

            //We want to seed the database with our own values each time the program builds, so
            //we seed the values after and before the hostbuilder is built and ran respectively as follows:

            //NOTE: This is only for dummy values purpose, in actual application you don't seed the same
            //values each time into a database.

            //First we store the build result into a variable.
            var hostResult = CreateHostBuilder(args).Build();

            //Among different components of host, we want the services, so storing them in scope var
            //using CreateScope()
            using(var scope = hostResult.Services.CreateScope())
            {
                try
                {
                    //Getting different services for our database.
                    var context = scope.ServiceProvider.GetService<BandAlbumContext>();
                    //We delete the present database each time and seed the one with our values each time.
                    context.Database.EnsureDeleted();
                    context.Database.Migrate();
                }
                catch(Exception e)
                {
                    //Syntax to display exception.
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occured while migrating.");
                }
            }

            //Build and migration(successful or unsuccessful) done. So running now.
            hostResult.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
