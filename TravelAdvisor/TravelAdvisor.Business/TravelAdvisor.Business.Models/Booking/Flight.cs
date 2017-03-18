using System;
using TravelAdvisor.Business.Models.Booking.Contracts;

namespace TravelAdvisor.Business.Models.Booking
{
	public class Flight : IFlight
	{
		public int Id { get; set; }

		public string FromDestination { get; set; }

		public string ToDestionation { get; set; }

		public DateTime Departure { get; set; }

		public DateTime Return { get; set; }

		public int PeopleCount { get; set; }

		public TravelClass TravelClass { get; set; }

		public bool IsDeleted { get; set; }
	}
}
