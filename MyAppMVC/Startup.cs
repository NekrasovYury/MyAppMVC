using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyAppMVC.Startup))]
namespace MyAppMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
