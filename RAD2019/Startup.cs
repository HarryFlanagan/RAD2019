using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RAD2019.Startup))]
namespace RAD2019
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
