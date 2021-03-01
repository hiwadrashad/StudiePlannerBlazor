using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudiePlannerBlazor.Server.Data;
using StudiePlannerBlazor.Server.Models;

[assembly: HostingStartup(typeof(StudiePlannerBlazor.Server.Areas.Identity.IdentityHostingStartup))]
namespace StudiePlannerBlazor.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}