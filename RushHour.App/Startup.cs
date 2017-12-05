using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RushHour.App.Startup))]
namespace RushHour.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
