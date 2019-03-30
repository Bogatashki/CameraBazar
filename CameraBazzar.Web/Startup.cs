using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CameraBazzar.Web.Startup))]
namespace CameraBazzar.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
