using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelryShop.Initializer;
using JewelryShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;

namespace JewelryShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDbContext>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.Configure<Stripe>(Configuration.GetSection("Stripe"));
            services.AddScoped<IDbUser, DbUser>();
            services.AddControllersWithViews();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IJewelryRepository, JewelryRepository>();
            services.AddScoped<ShoppingCart>(sc => ShoppingCart.GetCart(sc));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddRazorPages();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbUser dbUser)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];
            app.UseAuthentication();
            app.UseAuthorization();
            dbUser.Initializer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapRazorPages();
            });
        }
    }
}
