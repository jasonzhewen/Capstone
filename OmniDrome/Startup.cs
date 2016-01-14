using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OmniDrome.Startup))]
namespace OmniDrome
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
