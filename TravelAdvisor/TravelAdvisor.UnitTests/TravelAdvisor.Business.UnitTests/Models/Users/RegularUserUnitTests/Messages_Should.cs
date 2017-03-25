using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Users.RegularUserUnitTests
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
			var regularUser = new RegularUser { Messages = messageSet };

			//Act & Assert
			Assert.AreEqual(regularUser.Messages.First().Id, messageId);
		}
	}
}
