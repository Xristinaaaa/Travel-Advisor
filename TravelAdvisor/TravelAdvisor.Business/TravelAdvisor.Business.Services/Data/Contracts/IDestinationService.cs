using System.Linq;
using TravelAdvisor.Business.Models.Destinations;

namespace TravelAdvisor.Business.Services.Data.Contracts
{
	public interface IDestinationService
	{
		IQueryable<Destination> GetDestinations(int startAt, int count);

		IQueryable<Destination> GetAllDestinations();

		Destination FindByCountry(string country);

		void AddDestination(Destination destinationToAdd);
	}
}
