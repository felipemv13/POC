using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RazorViewExample.Startup))]
namespace RazorViewExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
