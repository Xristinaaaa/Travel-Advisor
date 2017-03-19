using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Cruises;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Models.Users.Contracts;

namespace TravelAdvisor.Business.Models.Users
{
	public class RegularUser : IRegularUser
	{
		private ICollection<Trip> trips;
		private ICollection<Cruise> cruises;
		private ICollection<CarRental> carRentals;
		private ICollection<Message> messages;

		public RegularUser()
		{
			this.trips = new HashSet<Trip>();
			this.cruises = new HashSet<Cruise>();
			this.carRentals = new HashSet<CarRental>();
			this.messages = new HashSet<Message>();
		}

		[Key, ForeignKey("ApplicationUser")]
		public string Id { get; set; }
		public virtual ApplicationUser ApplicationUser { get; set; }

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

		public virtual ICollection<Cruise> Cruises
		{
			get
			{
				return this.cruises;
			}
			set
			{
				this.cruises = value;
			}
		}

		public virtual ICollection<CarRental> CarRentals
		{
			get
			{
				return this.carRentals;
			}
			set
			{
				this.carRentals = value;
			}
		}

		public virtual ICollection<Message> Messages
		{
			get
			{
				return this.messages;
			}
			set
			{
				this.messages = value;
			}
		}
	}
}
