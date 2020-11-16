using System;
using ecommerce_EngSoftware.Areas.Identity.Data;
using ecommerce_EngSoftware.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ecommerce_EngSoftware.Areas.Identity.IdentityHostingStartup))]
namespace ecommerce_EngSoftware.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ecommerceDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ecommerceDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ecommerceDbContext>();
            });
        }
    }
}