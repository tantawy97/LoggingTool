using LoggingTool.Model;
using Microsoft.AspNetCore.Identity;

namespace LoggingTool.DatabaseSeed
{
    public class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
    public class DataSeeder
    {
        
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public DataSeeder(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
        
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task CreateUsersAndRolesAsync()
        {
            if (!await roleManager.RoleExistsAsync(Roles.Admin))
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            if (!await roleManager.RoleExistsAsync(Roles.User))
                await roleManager.CreateAsync(new IdentityRole(Roles.User));
            string adminUserEmail = "admin@email.com";

            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                var newAdminUser = new User()
                {
                    
                    UserName = "admin",
                    Email = adminUserEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAdminUser, "Password1");
                await userManager.AddToRoleAsync(newAdminUser, Roles.Admin);
            }


            string appUserEmail = "user@email.com";

            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new User()
                {
                   
                    UserName = "user",
                    Email = appUserEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAppUser, "Password1");
                await userManager.AddToRoleAsync(newAppUser, Roles.User);
            }
        }
    }

}
   