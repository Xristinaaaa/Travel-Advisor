using System.Linq;
using TravelAdvisor.Business.Models.Destinations;

namespace TravelAdvisor.Business.Services.Data.Contracts
{
	public interface IDestinationService
	{
		IQueryable<Destination> GetAllDestinations();

		void AddDestination(Destination destinationToAdd);
	}
}
