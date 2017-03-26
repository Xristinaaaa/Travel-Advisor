using System.Collections.Generic;

namespace TravelAdvisor.Web.Models.Destinations
{
	public class DestinationsListViewModel
	{
		public IEnumerable<DestinationItemViewModel> Destinations { get; set; }
	}
}