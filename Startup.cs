using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PMAprojekt.Areas.Identity.Data;
using PMAprojekt.DbModels;
using PMAprojekt.Models;
using PMAprojekt.Repositories;
using PMAprojekt.Services;
using PMAprojekt.Data;

namespace PMAprojekt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private void SetupDbContext(IServiceCollection services)
        {
            var connString = Configuration.GetConnectionString("ClosetDbContextConnection");
            services.AddDbContext<ClosetContext>(options => options.UseSqlServer(connString)); 
            //svakom servisu dodaj kontekst baze podataka koju mora gledati
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc().AddNewtonsoftJson();
            //dodajmo servise
            services.AddScoped<PostsRepository>();
            services.AddScoped<PostService>();
            services.AddScoped<ProductsRepository>();
            services.AddScoped<ProductService>();
            services.AddScoped<TypeOfProductRepository>();
            services.AddScoped<TypeOfProductService>();
            
            
            //services.AddIdentity<ApplicationUser, IdentityRole>(config => {
              //  config.Password.RequiredLength = 4;
            //})
              //  .AddEntityFrameworkStores<AppDb>()
                //.AddDefaultTokenProviders();

            
            
            SetupDbContext(services);

        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //Here you could create a super user who will maintain the web app
            var poweruser = new ApplicationUser
            {
                UserName = "Admin",
                Email = "admin@pmfst.hr",
            };
            //Ensure you have these values in your appsettings.json file
            string userPWD = "password";
            var _user = await UserManager.FindByEmailAsync("admin@pmfst.hr");

            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(poweruser, "Admin");

                }
            }

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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //CreateRoles(serviceProvider).Wait();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "Posts",
                    pattern: "posts",
                    defaults: new {controller="Post",action="Post"});
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "Products",
                    pattern: "Products",
                    defaults: new { controller = "Product", action = "Product" });
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "TypeOfProducts",
                    pattern: "TypeOfProducts",
                    defaults: new { controller = "TypeOfProduct", action = "TypeOfProduct" });
                endpoints.MapRazorPages();
            });
        }
    }
}
