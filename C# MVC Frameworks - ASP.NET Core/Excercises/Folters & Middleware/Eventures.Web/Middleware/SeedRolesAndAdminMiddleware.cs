namespace Eventures.Web.Middleware
{
    using Eventures.Data;
    using Eventures.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedRolesAndAdminMiddleware
    {
        private readonly RequestDelegate next;

        public SeedRolesAndAdminMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(
            HttpContext context,
            EventuresDbContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            if (await roleManager.RoleExistsAsync("User") == false)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            if (await roleManager.RoleExistsAsync("Admin") == false)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!dbContext.Users.Any(x => x.UserName == "Admin"))
            {
                var user = new User
                {
                    UserName = "Admin",
                    Email = "Admin@Admin.Admin",
                    FirstName = "Secret",
                    LastName = "Secret",
                };
                var result = await userManager.CreateAsync(user, "Admin");
                await userManager.AddToRoleAsync(user, "Admin");
            }
            await next(context);
        }
    }
}
