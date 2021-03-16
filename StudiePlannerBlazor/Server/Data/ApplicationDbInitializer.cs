using Microsoft.AspNetCore.Identity;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Server.Data
{
    public class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("test1@hotmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "test1@hotmail.com",
                    Email = "test1@hotmail.com"
                };

                //userManager.AddPasswordAsync(user, "Passw0rd!");

                IdentityResult result = userManager.CreateAsync(user, "Passw0rd!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
