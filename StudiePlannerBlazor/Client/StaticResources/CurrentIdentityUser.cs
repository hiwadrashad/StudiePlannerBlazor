using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client.StaticResources
{
    public static class CurrentIdentityUser
    {
        public static IdentityUser identityUser { get; set; } = new IdentityUser { Email = "test@hotmail.com", UserName = "test@hotmail.com"  };

    }
}
