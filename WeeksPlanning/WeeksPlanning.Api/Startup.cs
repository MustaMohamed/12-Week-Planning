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

namespace WeekPlanning.Api
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
            services.AddControllers()
                .AddFluentValidation();
            services.AddApplicationServices();
            services.AddApplicationValidationServices();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "Frontend/dist"; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSpaStaticFiles();
            
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "Frontend";
                if (env.IsDevelopment())
                {
                    // Launch development server for Vue.js
                    spa.UseReactDevelopmentServer("start");
                }
            });
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
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