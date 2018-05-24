using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dance_club.Startup))]
namespace dance_club
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
