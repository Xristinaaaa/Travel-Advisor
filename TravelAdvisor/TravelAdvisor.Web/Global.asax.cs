using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TravelAdvisor.Business.Data;
using TravelAdvisor.Business.Data.Migrations;

namespace TravelAdvisor.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
			ViewEnginesConfig.RegisterViewEngines();

			// Initialize database
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<TravelAdvisorDbContext, Configuration>());
		}
    }
}
