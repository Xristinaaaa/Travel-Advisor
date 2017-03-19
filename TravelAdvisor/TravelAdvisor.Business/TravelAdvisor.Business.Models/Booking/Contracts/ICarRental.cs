using System;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.Models.Booking.Contracts
{
	public interface ICarRental
	{
		int Id { get; set; }

		DateTime StartDate { get; set; }

		DateTime EndDate { get; set; }

		string Location { get; set; }

		int UserId { get; set; }

		RegularUser User { get; set; }

		int CarId { get; set; }

		Car Car { get; set; }

		bool IsDeleted { get; set; }
	}
}
