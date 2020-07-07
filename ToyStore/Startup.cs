using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToyStore.Startup))]
namespace ToyStore
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
