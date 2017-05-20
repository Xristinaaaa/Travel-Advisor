using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Web.App_Start.AutoMapper;

namespace TravelAdvisor.Web.Areas.Admin.Models.Destinations
{
	public class DestinationViewModel : IMapFrom<Destination>, IHaveCustomMappings
	{
		[DataType(DataType.Text)]
		[Required]
		[StringLength(ValidationConstants.MaxCountryLength, ErrorMessage = "Country name must be at least {2} characters long.", MinimumLength = ValidationConstants.MinCountryLength)]
		public string Country { get; set; }

		public int CountOfTrips { get; set; }

		public HttpPostedFileBase Image { get; set; }

		[DataType(DataType.ImageUrl)]
		public string ImageUrl { get; set; }

		[DataType(DataType.MultilineText)]
		[Required(ErrorMessage = "Description is required")]
		[StringLength(ValidationConstants.MaxDestinationDescriptionLength, ErrorMessage = "Description name must be at least {2} characters long.", MinimumLength = ValidationConstants.MinDestinationDescriptionLength)]
		[AllowHtml]
		public string Description { get; set; }

		public bool IsDeleted { get; set; }

		public void CreateMappings(IMapperConfigurationExpression config)
		{
			config.CreateMap<DestinationViewModel, Destination>()
				.ForMember(d => d.ImagePath, src => src.MapFrom(s => ("~/Images/" + s.Image.FileName)));
		}
	}
}