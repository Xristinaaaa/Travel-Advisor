using System.ComponentModel.DataAnnotations;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Destinations.Contracts;

namespace TravelAdvisor.Business.Models.Destinations
{
	public class Destination : IDestination
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(ValidationConstants.MinCountryLength), MaxLength(ValidationConstants.MaxCountryLength)]
		public string Country { get; set; }

		public int countOfTrips { get; set; }

		[Required]
		[MinLength(ValidationConstants.MinDestinationDescriptionLength), MaxLength(ValidationConstants.MinDestinationDescriptionLength)]
		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public string ImagePath { get; set; }

		public bool IsDeleted { get; set; }
	}
}
