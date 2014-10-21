using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamPyropeBlog.WebApp.Startup))]
namespace TeamPyropeBlog.WebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
