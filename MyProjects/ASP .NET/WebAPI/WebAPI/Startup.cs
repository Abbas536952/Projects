using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers(); By-default present in code.

            //Adding this will prompt an error whenever we donot support an output in XML or required format.
            //.AddXML... adds XML support.
            services.AddControllers(setupAction => setupAction.ReturnHttpNotAcceptable = true)
                .AddXmlDataContractSerializerFormatters();

            //Registering services for our repository. First we specify the interface, then the
            //implementation, and this registers our services between interface and implementation.
            services.AddScoped<IBandAlbumRepository, BandAlbumRepository>();

            //Adding our database.
            services.AddDbContext<BandAlbumContext>(options =>
            {
                //Configuration grabs the settings from appsettings.json.
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //Adding auto mapper to services.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //When the application runs in development mode, if any error occurs, this part will allow the error to be
            //displayed with all information.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //In production mode, no errors will be displayed and 500 Internal Server will pop up,
            //To show our custom message to the user, we implement the following for production mode.
            //Note that we cannot display the errors in same way as development mode because it can be exploited
            //and user has no concern with that long prompt.
            else //If development mode is not enabled.
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async c =>
                    {
                        c.Response.StatusCode = 500;
                        await c.Response.WriteAsync("Something went wrong!");
                    }
                    );
                }
                );
            }
            //In order to switch to production mode, open properties and write production instead of development
            //in debug section, save with the same screen open and run otherwise changes wont be saved if the
            //screen is switched to some other one.

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
