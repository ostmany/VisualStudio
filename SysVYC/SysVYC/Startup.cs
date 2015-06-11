using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SysVYC.Startup))]
namespace SysVYC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
