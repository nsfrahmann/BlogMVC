using BlogMVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMVC.Models;
using Microsoft.IdentityModel.Tokens;
using BlogMVC.Enums;

namespace BlogMVC.Utilities
{
    public static class SeedHelper
    {
        public static async Task SeedDataAsync(UserManager<BlogUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedAdmin(userManager);
            await SeedModerator(userManager);
        }
        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
        }
        private static async Task SeedAdmin(UserManager<BlogUser> userManager)
        {
            if (await userManager.FindByEmailAsync("nsfrahmann@gmail.com") == null)
            {
                var admin = new BlogUser()
                {
                    Email = "nsfrahmann@gmail.com",
                    UserName = "nsfrahmann@gmail.com",
                    FirstName = "Nathan",
                    LastName = "Frahmann",
                    DisplayName = "Blog Overlord",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "P@ssword1");
                await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
            }
        }
        private static async Task SeedModerator(UserManager<BlogUser> userManager)
        {
            if (await userManager.FindByEmailAsync("natefrahmann@gmail.com") == null)
            {
                var moderator = new BlogUser()
                {
                    Email = "natefrahmann@gmail.com",
                    UserName = "natefrahmann@gmail.com",
                    FirstName = "Nathan",
                    LastName = "Frahmann",
                    DisplayName = "Blog Mod",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(moderator, "P@ssword1");
                await userManager.AddToRoleAsync(moderator, Roles.Moderator.ToString());
            }            

        }
    }
}
