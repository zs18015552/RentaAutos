using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Frontera.Startup))]
namespace Frontera
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
