using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PawPaw.Startup))]
namespace PawPaw
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
