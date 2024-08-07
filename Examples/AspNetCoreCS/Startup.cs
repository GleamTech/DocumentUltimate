using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GleamTech.AspNet;
using GleamTech.AspNet.Core;
using GleamTech.DocumentUltimate;

namespace GleamTech.DocumentUltimateExamples.AspNetCoreCS
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
            services.AddControllersWithViews();


            //----------------------
            //Add GleamTech to the ASP.NET Core services container.
            services.AddGleamTech();
            //----------------------
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            //----------------------
            //Register GleamTech to the ASP.NET Core HTTP request pipeline.
            app.UseGleamTech(() =>
            {
                //The below custom config file loading is only for our demo publishing purpose:

                var gleamTechConfig = Hosting.ResolvePhysicalPath("~/App_Data/GleamTech.config");
                if (File.Exists(gleamTechConfig))
                    GleamTechConfiguration.Current.Load(gleamTechConfig);

                var documentUltimateConfig = Hosting.ResolvePhysicalPath("~/App_Data/DocumentUltimate.config");
                if (File.Exists(documentUltimateConfig))
                    DocumentUltimateConfiguration.Current.Load(documentUltimateConfig);
            });
            //----------------------


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
