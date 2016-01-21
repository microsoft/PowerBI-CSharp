using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcApp.Startup))]
namespace MvcApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigurePowerBI(app);
        }
    }
}
