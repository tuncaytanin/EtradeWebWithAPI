using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Mappings;
using Core.Extensions;
using Core.Utilities.Security.Token;
using Core.Utilities.Security.Token.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using DataAccess.Concrete.EntityFrameWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            IServiceCollection serviceCollections= services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer("Data Source=TANINPC;Initial Catalog=DbEtradeWebWithAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", options => options.MigrationsAssembly("DataAccess").MigrationsHistoryTable(HistoryRepository.DefaultTableName,"dbo")));
            services.AddControllers();
            services.AddCustomSwagger();
            services.AddCustomJwtToken(Configuration);

            services.AddCustomHttpContextAccessor();
            services.AddMemoryCache();
            

            //services.AddTransient<IUserService, UserService>();

            #region AutoMapper

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion


            #region DI
            // servislerimizi buraya ekliyoruz
            /* Bunları AutofacModule içerisinden ekledik
             services.AddTransient<IUserDal, EfUserDal>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, JwtTokenService>();
            services.AddTransient<IAuthService, AuthService>();
            */
            #endregion  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCustomSwagger();
                

            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticHttpContext();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
