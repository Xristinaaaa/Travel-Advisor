using System;

namespace TravelAdvisor.Business.Models.Cruises
{
	public class Cruise
	{
		public int Id { get; set; }

		public string DeparturePort { get; set; }

		public string CruiseLine { get; set; }

		public string CruiseShip { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public decimal Price { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public bool IsDeleted { get; set; }
	}
}
