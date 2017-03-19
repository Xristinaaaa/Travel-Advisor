namespace TravelAdvisor.Business.Models.Booking.Contracts
{
	public interface ICar
	{
		int Id { get; set; }

		string Model { get; set; }

		string ImageUrl { get; set; }

		string Description { get; set; }

		decimal RentalPrice { get; set; }

		bool IsDeleted { get; set; }
	}
}
