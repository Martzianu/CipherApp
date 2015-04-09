using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CipherApp.Startup))]
namespace CipherApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
