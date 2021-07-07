using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoanWeb_BanGame.Startup))]
namespace DoanWeb_BanGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
