using System;
using AutoMapper;
using TravelAdvisor.Business.Models.Cruises;
using TravelAdvisor.Web.App_Start.AutoMapper;

namespace TravelAdvisor.Web.Models.Cruises
{
    public class CruiseItemViewModel : IMapFrom<Cruise>, IHaveCustomMappings
    {
        public string DeparturePort { get; set; }

        public string CruiseLine { get; set; }

        public string CruiseShip { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int FreePlaces { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Cruise, CruiseItemViewModel>()
               .ForMember(d => d.ImagePath, src => src.MapFrom(s => s.ImagePath.Substring(1)));
        }
    }
}