using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PerformanteSolutionAPPUI.Startup))]
namespace PerformanteSolutionAPPUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
