using System;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.Models.Booking.Contracts
{
	public interface IFlightRequest
	{
		int Id { get; set; }

		string FromLocation { get; set; }

		string ToLocation { get; set; }

		DateTime Departure { get; set; }

		DateTime Return { get; set; }

		int PeopleCount { get; set; }

		TravelClass TravelClass { get; set; }

		string UserId { get; set; }

		RegularUser User { get; set; }

		bool IsDeleted { get; set; }
	}
}
