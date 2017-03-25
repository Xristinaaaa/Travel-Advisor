using System;
using System.ComponentModel.DataAnnotations;
using TravelAdvisor.Business.Models.Booking.Contracts;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.Models.Booking
{
	public class FlightRequest : IFlightRequest
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string FromLocation { get; set; }

		[Required]
		public string ToLocation { get; set; }

		public DateTime Departure { get; set; }

		public DateTime Return { get; set; }

		public int PeopleCount { get; set; }

		public TravelClass TravelClass { get; set; }

		[Required]
		public string UserId { get; set; }
		public virtual RegularUser User { get; set; }

		public bool IsDeleted { get; set; }
	}
}
