using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.AdminUnitTests
{
	[TestFixture]
	public class Messages_Should
	{
		[TestCase(12)]
		public void SetDataCorrectly(int messageId)
		{
			//Arrange
			var message = new Message { Id = messageId };
			var messageSet = new HashSet<Message> { message };
			var admin = new Admin { Messages = messageSet };

			//Act & Assert
			Assert.AreEqual(admin.Messages.First().Id, messageId);
		}
	}
}
