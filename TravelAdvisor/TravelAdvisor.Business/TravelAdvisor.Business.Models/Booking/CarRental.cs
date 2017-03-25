using System;
using System.ComponentModel.DataAnnotations;
using TravelAdvisor.Business.Models.Booking.Contracts;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.Models.Booking
{
	public class CarRental : ICarRental
	{
		[Key]
		public int Id { get; set; }
		
		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }
		
		public string Location { get; set; }

		[Required]
		public string UserId { get; set; }
		public virtual RegularUser User { get; set; }

		[Required]
		public int CarId { get; set; }
		public virtual Car Car { get; set; }

		public bool IsDeleted { get; set; }
	}
}
