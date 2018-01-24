using System;
using Microsoft.AspNetCore.Identity;

namespace Portfolio.Models
{
    public static class BlogIdentityDataIntializer
    {
        public static void SeedData(UserManager<BlogUser> userManager, RoleManager<BlogRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<BlogUser> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                BlogUser user = new BlogUser();
                user.UserName = "Admin";

                IdentityResult result = userManager.CreateAsync(user, "admin").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByNameAsync("User").Result == null)
            {
                BlogUser user = new BlogUser();
                user.UserName = "User";

                IdentityResult result = userManager.CreateAsync(user, "user").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<BlogRole> roleManager)
        {
            if(!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                BlogRole role = new BlogRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if(!roleManager.RoleExistsAsync("Administrator").Result)
            {
                BlogRole role = new BlogRole();
                role.Name = "Adminstration";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
