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

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    // Aqui você define a senha
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<ecommerceDbContext>();
            });
        }
    }
}