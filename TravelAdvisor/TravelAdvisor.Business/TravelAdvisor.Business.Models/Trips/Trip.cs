using System;
using System.ComponentModel.DataAnnotations;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Models.Trips.Contracts;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.Models.Trips
{
	public class Trip : ITrip
	{
		[Key]
		public int Id { get; set; }

		public string RegularUserId { get; set; }

		public virtual RegularUser User { get; set; }

		public int DestinationId { get; set; }

		public virtual Destination Destination { get; set; }

		[Required]
		[MinLength(ValidationConstants.MinTripDescriptionLength), MaxLength(ValidationConstants.MaxTripDescriptionLength)]
		public string Description { get; set; }

		public string ImageUrl { get; set; }
		
		public string ImagePath { get; set; }

		[Required]
		public string Accomodation { get; set; }

		[Required]
		public decimal Price { get; set; }
		
		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public int FreePlaces { get; set; }

		public bool IsDeleted { get; set; }
	}
}
