using System;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Models.Trips.Contracts;

namespace TravelAdvisor.Business.Models.Trips
{
	public class Trip : ITrip
	{
		public int Id { get; set; }

		public int DestinationId { get; set; }

		public virtual Destination Destination { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public string Accomodation { get; set; }

		public decimal Price { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public int FreePlaces { get; set; }

		public bool IsDeleted { get; set; }
	}
}
