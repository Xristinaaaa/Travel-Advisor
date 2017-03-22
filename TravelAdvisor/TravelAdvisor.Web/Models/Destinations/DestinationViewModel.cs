using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Web.App_Start.AutoMapper;

namespace TravelAdvisor.Web.Models.Destinations
{
	public class DestinationViewModel : IMapFrom<Destination>
	{
		public int Id { get; set; }

		public string Country { get; set; }

		public int countOfTrips { get; set; }

		public string ImageUrl { get; set; }

		public bool IsDeleted { get; set; }
	}
}