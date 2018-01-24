using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuestApp.Startup))]
namespace GuestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
