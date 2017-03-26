using System.ComponentModel.DataAnnotations;
using System.Web;
using AutoMapper;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Web.App_Start.AutoMapper;

namespace TravelAdvisor.Web.Areas.Admin.Models.Destinations
{
	public class DestinationViewModel : IMapFrom<Destination>, IHaveCustomMappings
	{
		[DataType(DataType.Text)]
		[Required]
		[StringLength(100, ErrorMessage = "Country name must be at least {2} characters long.", MinimumLength = 5)]
		public string Country { get; set; }

		public int CountOfTrips { get; set; }

		[DataType(DataType.ImageUrl)]
		public string ImageUrl { get; set; }

		public HttpPostedFileBase Image { get; set; }

		[DataType(DataType.MultilineText)]
		[Required(ErrorMessage = "Description is required")]
		[StringLength(10000, ErrorMessage = "Description name must be at least {2} characters long.", MinimumLength = 10)]
		public string Description { get; set; }

		public bool IsDeleted { get; set; }

		public void CreateMappings(IMapperConfigurationExpression config)
		{
			config.CreateMap<DestinationViewModel, Destination>()
				.ForMember(d => d.ImagePath, src => src.MapFrom(s => ("~/Images/" + s.Image.FileName)));
		}
	}
}