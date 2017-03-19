using TravelAdvisor.Business.Models.Booking.Contracts;

namespace TravelAdvisor.Business.Models.Booking
{
	public class Car : ICar
	{
		public int Id { get; set; }

		public string Model { get; set; }

		public string ImageUrl { get; set; }

		public string Description { get; set; }

		public decimal RentalPrice { get; set; }

		public bool IsDeleted { get; set; }
	}
}
