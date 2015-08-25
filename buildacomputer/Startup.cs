using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(buildacomputer.Startup))]
namespace buildacomputer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
