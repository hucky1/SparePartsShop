using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SparePartsShop.Models;
using SparePartsShop.Services.Data;
using SparePartsShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop
{
    public class Startup
    {
        public Startup(IConfiguration  configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<OrdersRepository>();
            services.AddTransient<ProductsRepository>();
            services.AddTransient<ShopCartRepository>();
            services.AddTransient<ClientsRepository>();
            services.AddTransient<ReviewsRepository>();
            // services.AddScoped(sp => ShopCartRepository.GetCart(sp));
            //services.AddTransient(sp => ShopCartRepository.GetCart(sp));


            //if (connection.Contains("[DataDirectory]"))
            //{
            //    connection = connection.Replace("[DataDirectory]", AppContext.BaseDirectory.Replace("\\","\\\\").Insert(2,"\\\\"));
            //}
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSession();
            
           
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "admin",
                   pattern: "admin",
                   defaults: new { controller = "Admin", action = "Login" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


            });
        }
    }
}
