using System.Data.Entity.Migrations;

namespace TravelAdvisor.Business.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<TravelAdvisorDbContext>
    {
        public Configuration()
        {
			this.AutomaticMigrationsEnabled = true;
			this.AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(TravelAdvisorDbContext context) { }
    }
}
