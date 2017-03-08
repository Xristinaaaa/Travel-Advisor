using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelAdvisor.Web.Startup))]
namespace TravelAdvisor.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
