namespace TravelAdvisor.Business.Models.Destinations.Contracts
{
	public interface IDestination
	{
		int Id { get; set; }

		string Country { get; set; }

		int countOfTrips { get; set; }

		string Description { get; set; }

		string ImageUrl { get; set; }

		bool IsDeleted { get; set; }
	}
}
