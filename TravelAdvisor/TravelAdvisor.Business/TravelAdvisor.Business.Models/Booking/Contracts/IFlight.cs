using System;

namespace TravelAdvisor.Business.Models.Booking.Contracts
{
	public interface IFlight
	{
		int Id { get; set; }

		string FromDestination { get; set; }

		string ToDestionation { get; set; }

		DateTime Departure { get; set; }

		DateTime Return { get; set; }

		int PeopleCount { get; set; }

		TravelClass TravelClass { get; set; }

		bool IsDeleted { get; set; }
	}
}
