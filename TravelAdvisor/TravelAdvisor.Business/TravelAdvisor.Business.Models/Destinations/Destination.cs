using TravelAdvisor.Business.Models.Destinations.Contracts;

namespace TravelAdvisor.Business.Models.Destinations
{
	public class Destination : IDestination
	{
		public int Id { get; set; }

		public string Country { get; set; }

		public int countOfTrips { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public bool IsDeleted { get; set; }
	}
}
