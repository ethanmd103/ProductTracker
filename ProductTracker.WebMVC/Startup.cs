using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductTracker.WebMVC.Startup))]
namespace ProductTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
