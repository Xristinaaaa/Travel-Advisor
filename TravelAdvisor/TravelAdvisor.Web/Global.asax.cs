using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TravelAdvisor.Web.App_Start;
using TravelAdvisor.Web.App_Start.AutoMapper;

namespace TravelAdvisor.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
			DatabaseConfig.Config();
			ViewEnginesConfig.RegisterViewEngines();
			AutoMapperConfig.Config(Assembly.GetExecutingAssembly());

			AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
    }
}
