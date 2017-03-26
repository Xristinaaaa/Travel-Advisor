using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using TravelAdvisor.Web.Models.Trips;

namespace TravelAdvisor.Web.Models.Manage
{
	public class IndexViewModel
	{
		public bool HasPassword { get; set; }

		public IList<UserLoginInfo> Logins { get; set; }

		public bool BrowserRemembered { get; set; }

		public TripsListViewModel UserTrips { get; set; }
	}
}