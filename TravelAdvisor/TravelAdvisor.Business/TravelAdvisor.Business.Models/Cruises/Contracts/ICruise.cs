using System;

namespace TravelAdvisor.Business.Models.Cruises.Contracts
{
	public interface ICruise
	{
		int Id { get; set; }

		string DeparturePort { get; set; }

		string CruiseLine { get; set; }

		string CruiseShip { get; set; }

		string Description { get; set; }

		string ImageUrl { get; set; }

		decimal Price { get; set; }

		DateTime StartDate { get; set; }

		DateTime EndDate { get; set; }

		bool IsDeleted { get; set; }
	}
}
