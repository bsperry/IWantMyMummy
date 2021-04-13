using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IWantMyMummy.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IWantMyMummy.Data
{
    public class IWantMyMummyContext : IdentityDbContext<IWantMyMummyUser>
    {
        public IWantMyMummyContext(DbContextOptions<IWantMyMummyContext> options) : base(options) { }
        //public IWantMyMummyContext() : base(GetRDSConnectionString()) { }

        public IWantMyMummyContext()
        {
        }
        public static IWantMyMummyContext Create() //Add this change
        {
            return new IWantMyMummyContext();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

}
