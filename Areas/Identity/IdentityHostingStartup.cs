using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using vr_backend.Areas.Identity.Data;

[assembly: HostingStartup(typeof(vr_backend.Areas.Identity.IdentityHostingStartup))]
namespace vr_backend.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<vr_backendIdentityDbContext>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("vr_backendIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options =>
                    options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<vr_backendIdentityDbContext>();
            });
        }
    }
}