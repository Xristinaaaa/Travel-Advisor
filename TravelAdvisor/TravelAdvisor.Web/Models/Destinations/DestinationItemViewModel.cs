using AutoMapper;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Web.App_Start.AutoMapper;

namespace TravelAdvisor.Web.Models.Destinations
{
	public class DestinationItemViewModel : IMapFrom<Destination>, IHaveCustomMappings
	{
		public string Country { get; set; }

		public int CountOfTrips { get; set; }
		
		public string ImageUrl { get; set; }

		public string Image { get; set; }

		public string Description { get; set; }

		public void CreateMappings(IMapperConfigurationExpression config)
		{
			config.CreateMap<Destination, DestinationItemViewModel>()
				.ForMember(d => d.Image, src => src.MapFrom(s => s.ImagePath.Substring(1)));
		}
	}
}