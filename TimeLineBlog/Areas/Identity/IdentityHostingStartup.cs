using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeLineBlog.Areas.Identity.Data;
using TimeLineBlog.Models;

[assembly: HostingStartup(typeof(TimeLineBlog.Areas.Identity.IdentityHostingStartup))]
namespace TimeLineBlog.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TimeLineBlogAccountContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TimeLineBlogAccountContextConnection")));

                services.AddDefaultIdentity<TimeLineBlogUser>()
                    .AddEntityFrameworkStores<TimeLineBlogAccountContext>();
            });
        }
    }
}