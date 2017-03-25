using NUnit.Framework;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.UnitTests.Models.Booking.MessageModel
{
	[TestFixture]
	public class SenderId_Should
	{
		[TestCase("sffsdag.123")]
		public void SetDataCorrectly(string userId)
		{
			//Arrange
			var applicationUser = new ApplicationUser { Id = userId };
			var message = new Message { SenderId = applicationUser.Id };

			//Act & Assert
			Assert.AreEqual(message.SenderId, userId);
		}
	}
}
