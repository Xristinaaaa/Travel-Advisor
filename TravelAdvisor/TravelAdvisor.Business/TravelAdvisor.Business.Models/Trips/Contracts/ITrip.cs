using System;
using TravelAdvisor.Business.Models.Destinations;

namespace TravelAdvisor.Business.Models.Trips.Contracts
{
	public interface ITrip
	{
		int Id { get; set; }

		int DestinationId { get; set; }

		Destination Destination { get; set; }

		string Description { get; set; }

		string ImageUrl { get; set; }

		string Accomodation { get; set; }

		decimal Price { get; set; }

		DateTime StartDate { get; set; }

		DateTime EndDate { get; set; }

		bool IsDeleted { get; set; }
	}
}
