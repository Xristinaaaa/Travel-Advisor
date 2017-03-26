using System.Collections.Generic;

namespace TravelAdvisor.Web.Models.Trips
{
	public class TripsListViewModel
	{
		public IEnumerable<TripItemViewModel> Trips { get; set; }
	}
}