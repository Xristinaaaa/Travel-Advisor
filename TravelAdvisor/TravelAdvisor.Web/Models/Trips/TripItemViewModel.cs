using System;
using System.Web;
using AutoMapper;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Web.App_Start.AutoMapper;

namespace TravelAdvisor.Web.Models.Trips
{
	public class TripItemViewModel : IMapFrom<Trip>, IHaveCustomMappings
	{
		public string Description { get; set; }

		public string ImagePath { get; set; }
		
		public string ImageUrl { get; set; }
		
		public string Accomodation { get; set; }
		
		public decimal Price { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public int FreePlaces { get; set; }

		public void CreateMappings(IMapperConfigurationExpression config)
		{
			config.CreateMap<Trip, TripItemViewModel>()
			   .ForMember(d => d.ImagePath, src => src.MapFrom(s => s.ImagePath.Substring(1)));
		}
	}
}