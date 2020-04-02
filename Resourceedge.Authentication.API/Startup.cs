using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Resourceedge.Authentication.API.IdentiyServer4;
using Resourceedge.Authentication.API.Services;
using Resourceedge.Authentication.Domain.Entities;
using Resourceedge.Authentication.Domain.Interfaces;

namespace Resourceedge.Authentication.API
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var AuthConnectionString = configuration.GetConnectionString("Auth");
            var Identity4ConnectionString = configuration.GetConnectionString("Identity4");

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy", cors =>
            //            cors.AllowAnyOrigin()
            //                .AllowAnyMethod()
            //                .AllowAnyHeader()
            //                );
            //});

            services.AddDbContext<EdgeDbContext>(config =>
            {
                config.UseSqlServer(AuthConnectionString
                //    options =>
                //{
                //    options.EnableRetryOnFailure()
                //    .MigrationsAssembly("Resourceedge.Authentication.API");
                //}
                );
            })
            .AddIdentity<ApplicationUser, ApplicationRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequiredUniqueChars = 0;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<EdgeDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Auth/Authenticate";
                config.Cookie.Name = "IdentityServer.Cookie";
            });
            var assembly = typeof(Startup).Assembly.GetName().Name;
            services.AddIdentityServer()
                .AddCorsPolicyService<CorsPolicyImplementation>()
                .AddAspNetIdentity<ApplicationUser>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(Identity4ConnectionString,
                        sql => sql.MigrationsAssembly(assembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(Identity4ConnectionString,
                        sql => sql.MigrationsAssembly(assembly));
                })
                .AddDeveloperSigningCredential();

            services.AddTransient<IAuthInterface, AuthServices>();

            services.AddControllersWithViews();
            //.AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors("CorsPolicy");
            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
