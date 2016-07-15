using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCdemo.Startup))]
namespace MVCdemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
