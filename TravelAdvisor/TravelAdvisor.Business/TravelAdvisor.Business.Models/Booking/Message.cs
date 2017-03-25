using System.ComponentModel.DataAnnotations;
using TravelAdvisor.Business.Common.Constants;
using TravelAdvisor.Business.Models.Booking.Contracts;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.Models.Booking
{
	public class Message : IMessage
	{
		[Key]
		public int Id { get; set; }
		
		public string Title { get; set; }

		public string Topic { get; set; }

		[Required]
		[MinLength(ValidationConstants.MinMessageText), MaxLength(ValidationConstants.MaxMessageText)]
		public string Text { get; set; }

		[Required]
		public string SenderId { get; set; }
		public ApplicationUser Sender { get; set; }

		[Required]
		public string ReceiverId { get; set; }
		public ApplicationUser Receiver { get; set; }

		public bool IsDeleted { get; set; }
	}
}
