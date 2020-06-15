using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TramitesWeb.Startup))]
namespace TramitesWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
