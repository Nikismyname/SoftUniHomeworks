namespace Eventures.Web.Utilities
{
    using Eventures.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;

    public class RolesAndAdminSeeder
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<User> userManager;

        public RolesAndAdminSeeder(
                RoleManager<IdentityRole> roleManager,
                UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async void Seed()
        {
                        ///Seeding the roles
            if (await roleManager.RoleExistsAsync("User") == false)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            if (await roleManager.RoleExistsAsync("Admin") == false)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            ///Crating the admin 
            if (userManager.Users.Any(x => x.UserName == "Admin") == false)
            {
                var user = new User
                {
                    UserName = "Admin",
                    Email = "Admin@Admin.Admin",
                    FirstName = "Admin1",
                    LastName = "Admin2",
                };
                var result = await userManager.CreateAsync(user, "Admin");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
