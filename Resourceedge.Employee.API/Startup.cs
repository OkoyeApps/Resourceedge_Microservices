using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Resourceedge.Employee.API.Services;
using Resourceedge.Employee.Domain.DbContext;
using Resourceedge.Employee.Domain.Interfaces;
namespace Resourceedge.Employee.API
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        private static readonly string[] Headers = new[] { "X-Operation", "X-Resource", "X-Total-Count", "X-Pagination" };

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(config =>
                {
                    config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders(Headers);
                });
            });

            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", config =>
            {
                config.Authority = Configuration["Services:Authority"];
                config.Audience = "Employee";
                config.RequireHttpsMetadata = false;
            });

            services.AddHttpClient("OldEdge", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:oldResourceedge"]);
            });

            services.AddTransient<IDbContext, EmployeeDbContext>(ctx => EmployeeDbContext.Create(
               Configuration.GetSection("DefaultConnection:ConnectionString").Value,
               Configuration.GetSection("DefaultConnection:DataBaseName").Value));
            services.AddTransient<IEmployee, ArchiveServices>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;

            })
            .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
            .AddXmlDataContractSerializerFormatters();


            services.Configure<MvcOptions>(config =>
            {
                var newtonsoftJsonOutputFormatter = config.OutputFormatters.OfType<NewtonsoftJsonOutputFormatter>()?.FirstOrDefault();
                if (newtonsoftJsonOutputFormatter != null)
                {
                    newtonsoftJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.marvin.hateoas+json");
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Initializer.SeedEmployeeDb(app);
        }
    }
}
