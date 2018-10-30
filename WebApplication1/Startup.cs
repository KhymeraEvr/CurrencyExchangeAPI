using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Models;
using WebApplication1.Models.Authentication;
using WebApplication1.Models.DbContexts;
using WebApplication1.Models.UnitOfWork;
using WebApplication1.Services;

namespace WebApplication1
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                     {
                         options.RequireHttpsMetadata = false;
                         options.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidateLifetime = true,
                             IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                             ValidateIssuerSigningKey = true,
                         };
                     });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;


                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=ConversionDB;Trusted_Connection=True";
            services.AddDbContext<ConversionsContext>(options =>
                options.UseSqlServer(connectionString));
            var connectionString2 = @"Server=(localdb)\MSSQLLocalDB;Database=UsersDB;Trusted_Connection=True";
            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(connectionString2));
            services.AddMemoryCache();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IGraphService, GraphService>();
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IConversionContext, ConversionsContext>();
            services.AddScoped<IUserContext, UserContext>();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            AutoMapper.Mapper.Initialize(cfg => { cfg.CreateMap<ResponseModel, RatesModel>(); });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Register}/{id?}");
            });
        }
    }
}
