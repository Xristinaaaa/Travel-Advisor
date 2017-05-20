using System;
using AutoMapper;
using TravelAdvisor.Business.Models.Cruises;
using TravelAdvisor.Web.App_Start.AutoMapper;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;
using TravelAdvisor.Business.Common.Constants;

namespace TravelAdvisor.Web.Areas.Admin.Models.Cruises
{
    public class CruiseViewModel : IMapFrom<Cruise>, IHaveCustomMappings
    {
        public string DeparturePort { get; set; }
   
        public string CruiseLine { get; set; }

        public string CruiseShip { get; set; }

        public HttpPostedFileBase Image { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(ValidationConstants.MaxCruiseDescriptionLength, ErrorMessage = "Description name must be at least {2} characters long.", MinimumLength = ValidationConstants.MinCruiseDescriptionLength)]
        [AllowHtml]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int FreePlaces { get; set; }

        public bool IsDeleted { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<CruiseViewModel, Cruise>()
                .ForMember(d => d.ImagePath, src => src.MapFrom(s => ("~/Images/" + s.Image.FileName)));
        }
    }
}