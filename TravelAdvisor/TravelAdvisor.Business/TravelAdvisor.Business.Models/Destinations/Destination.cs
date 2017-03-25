using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Destinations.Contracts;
using TravelAdvisor.Business.Models.Trips;

namespace TravelAdvisor.Business.Models.Destinations
{
	public class Destination : IDestination
	{
		private ICollection<Trip> trips;

		public Destination(string country)
		{
			this.Country = country;
		}

		public Destination()
		{
			this.trips = new HashSet<Trip>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(ValidationConstants.MinCountryLength), MaxLength(ValidationConstants.MaxCountryLength)]
		public string Country { get; set; }

		public int CountOfTrips { get; set; }

		[Required]
		[MinLength(ValidationConstants.MinDestinationDescriptionLength), MaxLength(ValidationConstants.MaxDestinationDescriptionLength)]
		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public string ImagePath { get; set; }

		public bool IsDeleted { get; set; }

		public virtual ICollection<Trip> Trips
		{
			get
			{
				return this.trips;
			}
			set
			{
				this.trips = value;
			}
		}
	}
}
