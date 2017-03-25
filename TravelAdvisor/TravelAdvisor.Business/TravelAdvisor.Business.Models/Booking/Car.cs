using System.ComponentModel.DataAnnotations;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Booking.Contracts;

namespace TravelAdvisor.Business.Models.Booking
{
	public class Car : ICar
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Model { get; set; }

		public string ImageUrl { get; set; }
		
		[MinLength(ValidationConstants.MinCarDescriptionLength), MaxLength(ValidationConstants.MaxCarDescriptionLength)]
		public string Description { get; set; }

		[Required]
		public decimal RentalPrice { get; set; }

		public bool IsDeleted { get; set; }
	}
}
