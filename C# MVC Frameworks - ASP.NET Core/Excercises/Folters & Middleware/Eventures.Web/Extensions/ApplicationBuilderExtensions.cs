namespace Eventures.Web.Extensions
{
    using Eventures.Web.Middleware;
    using Microsoft.AspNetCore.Builder;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSeedRolesAndAdmin(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SeedRolesAndAdminMiddleware>();
        }
    }
}
