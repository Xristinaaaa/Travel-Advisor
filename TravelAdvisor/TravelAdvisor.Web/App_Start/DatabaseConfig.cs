using System.Data.Entity;
using TravelAdvisor.Business.Data;
using TravelAdvisor.Business.Data.Migrations;

namespace TravelAdvisor.Web
{
	public class DatabaseConfig
	{
		public static void Config()
		{
			// Initialize database
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<TravelAdvisorDbContext, Configuration>());
		}
	}
}