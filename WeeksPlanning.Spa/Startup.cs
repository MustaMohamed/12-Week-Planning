using System.Data.SqlClient;
using System.Diagnostics;
using FluentValidation.AspNetCore;
using Framework.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using WeeksPlanning.Core.Features.ValidationConfiguration;

namespace WeeksPlanning.Spa
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
            ConfigureLlbl();
            services.AddControllersWithViews().AddFluentValidation();
            
            services.AddApplicationServices();
            services.AddApplicationValidationServices();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
        
        private void ConfigureLlbl()
        {
            string cs = Configuration.GetConnectionString("WeeksPlanning");
            RuntimeConfiguration.AddConnectionString("ConnectionString.SQL Server (SqlClient)", cs);
            RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(c =>
            {
                c.AddDbProviderFactory(typeof(SqlClientFactory));
                c.SetTraceLevel(TraceLevel.Verbose);
            });
        }
    }
}