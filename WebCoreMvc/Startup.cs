using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreMvc.ApiServices;
using WebCoreMvc.ApiServices.Interfaces;
using WebCoreMvc.Handlers;

namespace WebCoreMvc
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
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddScoped<AuthTokenHandler>();

            #region HttpClinet
            services.AddHttpClient<IAuthApiService, AuthApiService>(opt =>
                opt.BaseAddress = new Uri(Configuration["BaseUrl"])
            );
            services.AddHttpClient<IUserApiService, UserApiService>(opt =>
                opt.BaseAddress = new Uri(Configuration["BaseUrl"])
            ).AddHttpMessageHandler<AuthTokenHandler>();
            #endregion
            #region cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
            {
                opt.LoginPath = "/Admin/Auth/Index";
                opt.ExpireTimeSpan = TimeSpan.FromDays(60);
                opt.SlidingExpiration = true;
                opt.Cookie.Name = "mvccookie";
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

                app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseStatusCodePagesWithRedirects("/Admin/Error/MystatusCode?code={0}");
            
            app.UseSession();
            app.UseStaticFiles();
       
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //  -> Admin/Home/Index
                endpoints.MapAreaControllerRoute(
                    areaName: "Admin",
                      name: "Admin",
                      pattern: "Admin/{controller=Home}/{action=Index}/{id?}"

                );
                // -> Home/Index
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
