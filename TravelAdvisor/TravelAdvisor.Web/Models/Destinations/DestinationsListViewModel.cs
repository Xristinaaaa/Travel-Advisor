using System.Collections.Generic;

namespace TravelAdvisor.Web.Models.Destinations
{
	public class DestinationsListViewModel
	{
		public IEnumerable<DestinationViewModel> Destinations { get; set; }
	}
}