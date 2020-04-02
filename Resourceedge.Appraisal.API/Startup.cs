using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
using Polly;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.API.Services;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Email.Api.SGridClient;

namespace Resourceedge.Appraisal.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        private static readonly string[] Headers = new[] { "X-Operation", "X-Resource", "X-Total-Count", "X-Pagination" };

        public Startup(IConfiguration _config)
        {
            Configuration = _config;
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
                config.Audience = "Appraisal";
                config.RequireHttpsMetadata = false;
            });
            services.AddHttpClient("EmployeeService", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:employee"]);
                config.DefaultRequestHeaders.Clear();
                config.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500))); ;


            services.AddTransient<IDbContext, EdgeAppraisalContext>(ctx => EdgeAppraisalContext.Create(
                Configuration.GetSection("DefaultConnection:ConnectionString").Value,
                Configuration.GetSection("DefaultConnection:DataBaseName").Value));

            services.AddTransient<ISGClient, SGClient>(ctx => SGClient.Create(
                Configuration.GetSection("SendGrid:SENDGRID_API_KEY").Value));

            services.AddTransient<IKeyResultArea, KeyResultAreaService>();
            services.AddTransient<IAppraisalConfig, AppraisalConfigService>();
            services.AddTransient<IAppraisalResult, AppraisalResultService>();
            services.AddTransient<ITeamRepository, TeamService>();
            services.AddTransient<ICoreValue, CoreValueService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters()
            .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

      

            services.Configure<MvcOptions>(config =>
            {
                var newtonsoftJsonOutputFormatter = config.OutputFormatters.OfType<NewtonsoftJsonOutputFormatter>()?.FirstOrDefault();
                if (newtonsoftJsonOutputFormatter != null)
                {
                    newtonsoftJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.marvin.hateoas+json");
                }
            });
        }

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
           InitializerService.Seed(app);
        }
    }
}
