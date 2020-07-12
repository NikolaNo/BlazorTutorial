using System;
using EmployeeManagment.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EmployeeManagment.Web.Areas.Identity.IdentityHostingStartup))]
namespace EmployeeManagment.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EmployeeManagmentWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EmployeeManagmentWebContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<EmployeeManagmentWebContext>();
            });
        }
    }
}