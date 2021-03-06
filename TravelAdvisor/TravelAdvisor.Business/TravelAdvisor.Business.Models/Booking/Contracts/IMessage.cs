﻿using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.Models.Booking.Contracts
{
	public interface IMessage
	{
		int Id { get; set; }

		string Title { get; set; }

		string Topic { get; set; }

		string Text { get; set; }
		
		string SenderId { get; set; }

		ApplicationUser Sender { get; set; }

		string ReceiverId { get; set; }

		ApplicationUser Receiver { get; set; }

		bool IsDeleted { get; set; }
	}
}
