using System.Collections.Generic;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.Services.Data.Contracts
{
	public interface IUserService
	{
		IEnumerable<Trip> GetUserTrips(string userId);

		void AddTripToWishlist(Trip tripToAdd, string userId);
	}
}
