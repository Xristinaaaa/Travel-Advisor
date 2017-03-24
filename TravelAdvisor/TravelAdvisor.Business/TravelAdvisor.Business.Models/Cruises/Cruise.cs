using System;
using System.ComponentModel.DataAnnotations;
using TravelAdvisor.Business.Models.Cruises.Contracts;

namespace TravelAdvisor.Business.Models.Cruises
{
	public class Cruise : ICruise
	{
		[Key]
		public int Id { get; set; }

		public string DeparturePort { get; set; }

		public string CruiseLine { get; set; }

		public string CruiseShip { get; set; }

		[Required]
		public string Description { get; set; }

		public string ImageUrl { get; set; }

		[Required]
		public decimal Price { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public int FreePlaces { get; set; }

		public bool IsDeleted { get; set; }
	}
}
