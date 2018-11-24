using Microsoft.AspNetCore.Hosting;


[assembly: HostingStartup(typeof(Eventures.Web.Areas.Identity.IdentityHostingStartup))]
namespace Eventures.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}