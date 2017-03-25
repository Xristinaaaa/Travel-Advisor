namespace TravelAdvisor.Business.Models.Destinations.Contracts
{
	public interface IDestination
	{
		int Id { get; set; }

		string Country { get; set; }

		int CountOfTrips { get; set; }

		string Description { get; set; }

		string ImageUrl { get; set; }

		string ImagePath { get; set; }

		bool IsDeleted { get; set; }
	}
}
