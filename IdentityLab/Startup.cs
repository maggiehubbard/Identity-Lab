using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityLab.Startup))]
namespace IdentityLab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
