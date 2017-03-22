﻿using TravelAdvisor.Business.Models.Booking.Contracts;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.Models.Booking
{
	public class Message : IMessage
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Topic { get; set; }

		public string Text { get; set; }

		public int SenderId { get; set; }

		public ApplicationUser Sender { get; set; }

		public int ReceiverId { get; set; }

		public ApplicationUser Receiver { get; set; }

		public bool IsDeleted { get; set; }
	}
}