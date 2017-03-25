using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.MessageModel
{
	[TestFixture]
	public class Receiver_Should
	{
		[TestCase("adas12344.sdf")]
		public void SetDataCorrectly(string userId)
		{
			//Arrange
			var applicationUser = new ApplicationUser { Id = userId };
			var message = new Message { Receiver = applicationUser };

			//Act & Assert
			Assert.AreEqual(message.Receiver.Id, userId);
		}
	}
}
