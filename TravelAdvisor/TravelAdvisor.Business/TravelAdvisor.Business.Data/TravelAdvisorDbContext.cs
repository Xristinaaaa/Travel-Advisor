using Microsoft.AspNet.Identity.EntityFramework;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.Data
{
	public class TravelAdvisorDbContext : IdentityDbContext<User>
	{
		public TravelAdvisorDbContext()
            : base("TravelAdvisor", throwIfV1Schema: false)
        {
		}

		public static TravelAdvisorDbContext Create()
		{
			return new TravelAdvisorDbContext();
		}
	}
}
