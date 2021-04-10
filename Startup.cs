using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IWantMyMummy.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



namespace IWantMyMummy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; set; }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();



            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
            });
            services.AddMvc();

            services.AddDbContext<MummyContext>(options =>
               options.UseSqlServer(Configuration["ConnectionStrings:IWantMyMummyContextConnection"]));
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();



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



            app.UseRouting();
            app.UseAuthentication();



            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                //filter and page
                endpoints.MapControllerRoute("filterId",
                   "/{filterId}",
                   new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("locationns",
                    "{locationns}",
                    new { Controller = "Burials", action = "Index", pageNum = 1 }
                    );
                endpoints.MapControllerRoute("pageNum",
                    "Burials/All/Page{pageNum}",
                    new { Controller = "Burials", action = "Index" });
                endpoints.MapControllerRoute("pageNum",
                    "Burials/All/Page{pageNum}/{filterId}",
                    new { Controller = "Burials", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
