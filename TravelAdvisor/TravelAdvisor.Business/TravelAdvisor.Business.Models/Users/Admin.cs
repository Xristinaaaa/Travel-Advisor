using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Users.Contracts;

namespace TravelAdvisor.Business.Models.Users
{
	public class Admin : IAdmin
	{
		private ICollection<CarRental> carRentals;
		private ICollection<FlightRequest> flightRequests;
		private ICollection<Message> messages;

		public Admin()
		{
			this.carRentals = new HashSet<CarRental>();
			this.flightRequests = new HashSet<FlightRequest>();
			this.messages = new HashSet<Message>();
		}

		[Key, ForeignKey("ApplicationUser")]
		public string Id { get; set; }
		public virtual ApplicationUser ApplicationUser { get; set; }

		public bool IsDeleted { get; set; }

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

		public virtual ICollection<FlightRequest> FlightRequests
		{
			get
			{
				return this.flightRequests;
			}
			set
			{
				this.flightRequests = value;
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
