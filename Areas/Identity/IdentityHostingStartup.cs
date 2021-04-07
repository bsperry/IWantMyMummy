using System;
using IWantMyMummy.Areas.Identity.Data;
using IWantMyMummy.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IWantMyMummy.Areas.Identity.IdentityHostingStartup))]
namespace IWantMyMummy.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IWantMyMummyContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IWantMyMummyContextConnection")));

                services.AddDefaultIdentity<IWantMyMummyUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IWantMyMummyContext>();
            });
        }
    }
}