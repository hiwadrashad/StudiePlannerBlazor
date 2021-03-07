using Microsoft.AspNetCore.Identity;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.StaticResources
{
    public static class CurrentIdentityUser
    {
        public static ApplicationUser appuser { get; set; } = new ApplicationUser { Email = "test@hotmail.com", UserName = "test@hotmail.com"  };

    }
}
