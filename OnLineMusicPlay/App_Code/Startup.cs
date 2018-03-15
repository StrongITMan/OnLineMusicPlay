using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnLineMusicPlay.Startup))]
namespace OnLineMusicPlay
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
