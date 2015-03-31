using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Playground.Startup))]
namespace MVC_Playground
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
