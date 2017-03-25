using System.Linq;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.Services.Data.Contracts
{
	public interface ITripService
	{
		IQueryable<Trip> GetAllTrips();

		void AddTrip(Trip tripToAdd);
	}
}
