using System;

namespace TravelAdvisor.Business.Models.Booking.Contracts
{
	public interface ICarRental
	{
		int Id { get; set; }

		string CarModel { get; set; }

		string ImageUrl { get; set; }

		DateTime StartDate { get; set; }

		DateTime EndDate { get; set; }

		string Location { get; set; }

		bool IsDeleted { get; set; }
	}
}
