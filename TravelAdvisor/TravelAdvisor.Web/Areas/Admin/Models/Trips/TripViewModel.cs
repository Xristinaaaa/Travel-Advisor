using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using AutoMapper;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Web.App_Start.AutoMapper;

namespace TravelAdvisor.Web.Areas.Admin.Models.Trips
{
	public class TripViewModel : IMapFrom<Trip>, IHaveCustomMappings
	{
		public string Destination { get; set; }

		[DataType(DataType.Text)]
		[Required]
		[StringLength(10000, ErrorMessage = "Description name must be at least {2} characters long.", MinimumLength = 5)]
		public string Description { get; set; }

		public HttpPostedFileBase ImagePath { get; set; }

		[DataType(DataType.ImageUrl)]
		public string ImageUrl { get; set; }

		[Required]
		public string Accomodation { get; set; }

		[Required]
		public decimal Price { get; set; }
		
		public DateTime StartDate { get; set; }
		
		public DateTime EndDate { get; set; }

		public int FreePlaces { get; set; }

		public bool IsDeleted { get; set; }

		public void CreateMappings(IMapperConfigurationExpression config)
		{
			config.CreateMap<TripViewModel, Trip>()
				.ForMember(d => d.ImagePath, src => src.MapFrom(s => ("~/Images/" + s.ImagePath.FileName)));

			config.CreateMap<TripViewModel, Trip>()
				.ForMember(d => d.Destination, src => src.MapFrom(s => new Destination(s.Destination)));
		}
	}
}