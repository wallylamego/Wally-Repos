using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CicotiWebApp;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace CicotiWebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.Stores.MaxLengthForKeys = 128)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        private async Task CreateRolesAsync(IServiceProvider serviceProvider)
        {
            //initial roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Admin", "Manager", "Employee"};
            Task<IdentityResult> roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist =  RoleManager.RoleExistsAsync(roleName);
                if (!roleExist.Result)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult =  RoleManager.CreateAsync(new IdentityRole(roleName));
                    roleResult.Wait();
                }
            }
            IConfigurationRoot Configuration;
            //Here you could create a super user who will maintain the web app
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            //Ensure you have these values in your appsettings.json file
            string userPWD = Configuration["UserPassword"];
            ApplicationUser user = await UserManager.FindByEmailAsync(Configuration["UserEmail"]);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = Configuration["UserName"],
                    Email = Configuration["UserEmail"]
                };
                await UserManager.CreateAsync(user, userPWD);
                user = await UserManager.FindByEmailAsync(Configuration["UserEmail"]);
            }
               
            bool IsInRole = await UserManager.IsInRoleAsync(user, "Admin");
            IdentityResult r;
            if (!IsInRole)
            {
                IsInRole = false;
                try
                {
                    bool role = await RoleManager.RoleExistsAsync("Admin");
                    r = await UserManager.AddToRoleAsync(user, "Admin");
                }
                catch(Exception e)
                {
                    IsInRole = false;
                    
                }
                
                
            }
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            //Create the roles
             CreateRolesAsync(serviceProvider);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
