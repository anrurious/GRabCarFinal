using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrabCarMVC.Startup))]
namespace GrabCarMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
