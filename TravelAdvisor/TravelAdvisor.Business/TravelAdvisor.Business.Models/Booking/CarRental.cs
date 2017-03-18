using System;
using TravelAdvisor.Business.Models.Booking.Contracts;

namespace TravelAdvisor.Business.Models.Booking
{
	public class CarRental : ICarRental
	{
		public int Id { get; set; }

		public string CarModel { get; set; }

		public string ImageUrl { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }
		
		public string Location { get; set; }

		public bool IsDeleted { get; set; }
	}
}
