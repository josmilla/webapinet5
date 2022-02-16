using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Net5.Deployment.API.Infrastructure.Data.Contexts;
using Net5.Deployment.API.Infrastructure.Data.Repositories;
using Net5.Deployment.API.Infrastructure.HealthChecks;
using Serilog;
using System;

namespace Net5.Deployment.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Net5.Deployment.API", Version = "v1" });
            });
            string connectionString = Configuration.GetConnectionString("ProductConnectionString");
            services.AddDbContext<AlumnoContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IAlumnoRepository,AlumnoRepository>();

            services.AddHealthChecks()
                .AddDbContextCheck<AlumnoContext>()
                .AddUrlGroup(new Uri("http://google.com"),name:"Google Inc.")
                .AddCheck<CustomHealthCheck>(name:"New Custom Check")
                .AddCheck("CatalogDB-Check",new SqlConnectionHealthCheck(connectionString),HealthStatus.Unhealthy,new string[] { "catalogdb"});

            services.AddHealthChecksUI()
                .AddInMemoryStorage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AlumnoContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Net5.Deployment.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            context.EnsureSeeDataForContext();
            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseHealthChecks("/health");

            //app.UseHealthChecks("/health",new HealthCheckOptions
            //{
            //    ResponseWriter = async (context, report) =>
            //    {
            //        context.Response.ContentType = "application/json";
            //        var response = new HealthCheckResponse
            //        {
            //            Status = report.Status.ToString(),
            //            HealthChecks = report.Entries.Select(x => new IndividualHealthCheckResponse
            //            {
            //                Component = x.Key,
            //                Status = x.Value.Status.ToString(),
            //                Description = x.Value.Description
            //            }),
            //            HealthCheckDuration = report.TotalDuration
            //        };
            //        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            //    }
            //});

            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(config => config.UIPath = "/health-ui");
        }
    }
}
