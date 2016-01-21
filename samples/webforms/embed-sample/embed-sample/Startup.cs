using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(embed_sample.Startup))]
namespace embed_sample
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigurePowerBI(app);
        }
    }
}
