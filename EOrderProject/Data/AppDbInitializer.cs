using EOrderProject.Data.Static;
using EOrderProject.Models;
using Microsoft.AspNetCore.Identity;

namespace EOrderProject.Data
{
    public class AppDbInitializer
    {
        public static async Task SeedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope= applicationBuilder.ApplicationServices.CreateScope()){
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                //context.Database.EnsureCreated();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminUserEmail = "admin@eorder.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Test@123?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@eorder.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);

                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Test@123?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
