using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DCRHAK.Startup))]
namespace DCRHAK
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
