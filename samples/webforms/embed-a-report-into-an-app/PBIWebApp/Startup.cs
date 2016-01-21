using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PBIWebApp.Startup))]
namespace PBIWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}