using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Sys_Recom_EComm_PC_comp.Areas.Identity.IdentityHostingStartup))]
namespace Sys_Recom_EComm_PC_comp.Areas.Identity
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